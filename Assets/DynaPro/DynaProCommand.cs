
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Beamable.Common;
using Beamable.Common.BeamCli;
using Beamable.Coroutines;
using DynaPro;
using UnityEngine;
using Debug = UnityEngine.Debug;


[Serializable]
public class CommandDataDesc
{
	public string type;
	public string json;
}
[Serializable]
public class CommandData<T>
{
	public string type;
	public T data;
}

public class DynaProCommandExecution
{
	private readonly DynaProCommand _command;
	private Process _process;

	private Task _task;
	public Promise Completion { get; private set; } = new Promise();
	
	private string messageBuffer = "";
	private bool isMessageInProgress;

	private List<CommandDataDesc> _points = new List<CommandDataDesc>();
	Action<CommandDataDesc> _callbacks = (_) => { };
	public DynaProCommandExecution(DynaProCommand command, Action<CommandDataDesc> callbacks)
	{
		_command = command;
		_callbacks = callbacks;
		_task = Task.Run(Start);
		
		command.CoroutineService.StartNew("dyna-command", WaitForTask());
	}

	
	IEnumerator WaitForTask()
	{
		while (true)
		{
			if (_points.Count > 0)
			{
				foreach (var pt in _points)
				{
					_callbacks?.Invoke(pt);
				}

				_points.Clear();
			}

			if (_task.IsCompleted)
			{
				Completion.CompleteSuccess();
				yield break;
			}

			if (_task.IsFaulted)
			{
				Completion.CompleteError(_task.Exception);
				yield break;
			}

			yield return null;
		}
	}
	
	private void Start()
	{
				
		using (_process = new System.Diagnostics.Process())
		{
			_process.StartInfo.FileName = "cmd.exe";
			_process.StartInfo.Arguments = $"/C {_command.Command}"; 
			// Configure the process using the StartInfo properties.
			_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
			_process.EnableRaisingEvents = true;
			_process.StartInfo.RedirectStandardInput = true;
			_process.StartInfo.RedirectStandardOutput = true;
			_process.StartInfo.RedirectStandardError = true;
			_process.StartInfo.CreateNoWindow = true;
			_process.StartInfo.UseShellExecute = false;
				
			_process.EnableRaisingEvents = true;

			_process.OutputDataReceived += (sender, args) => ProcessStandardOut(args?.Data);
			_process.ErrorDataReceived += (sender, args) => ProcessStandardErr(args?.Data);

			_process.Start();

			_process.BeginOutputReadLine();
			_process.BeginErrorReadLine();

			_process.WaitForExit();

		}

	}
	
	
	private void ProcessStandardOut(string message)
	{
		if (message == null) return;

		if (_command.Settings.logDebug)
		{
			Debug.Log($"dynaPro command=[{_command.Command}] message=[{message}]");
		}
		
		messageBuffer += message;
		if (!isMessageInProgress)
		{
			var startIndex = messageBuffer.IndexOf(Reporting.PATTERN_START, StringComparison.Ordinal);
			if (startIndex >= 0)
			{
				isMessageInProgress = true;
				messageBuffer = messageBuffer.Substring(startIndex + Reporting.PATTERN_START.Length);
			}
		}
		else if (isMessageInProgress)
		{
			var startIndex = messageBuffer.IndexOf(Reporting.PATTERN_END, StringComparison.Ordinal);
			if (startIndex >= 0)
			{
				isMessageInProgress = false;
				var found = messageBuffer.Substring(0, startIndex);
				messageBuffer = messageBuffer.Substring(startIndex + Reporting.PATTERN_END.Length);
				// Debug.LogWarning(found);

				var pt = JsonUtility.FromJson<CommandDataDesc>(found);
				if (pt != null)
				{
					pt.json = found;
					_points.Add(pt);
				}
			}
		}
	}

	private void ProcessStandardErr(string data)
	{
		if (data == null) return;
		// if (_command.Settings.logDebug)
		// {
		// 	Debug.Log($"dynaPro command=[{_command.Command}] message=[{message}]");
		// }
		Debug.LogError(data);
	}
}


public class DynaProCommand
{
	public CoroutineService CoroutineService { get; }
	public string Command { get; }
	public DynaProSettings Settings { get; }

	private Action<CommandDataDesc> _callbacks = (_) => { };
	public DynaProCommand(string command, DynaProSettings settings, CoroutineService coroutineService)
	{
		Command = command;
		Settings = settings;
		CoroutineService = coroutineService;
	}

	public DynaProCommand On<T>(string type, Action<CommandData<T>> cb)
	{
		On(desc =>
		{
			if (desc.type != type) return;
			var pt = JsonUtility.FromJson<CommandData<T>>(desc.json);
			cb?.Invoke(pt);
		});

		return this;
	}

	public DynaProCommand On(Action<CommandDataDesc> cb)
	{
		_callbacks += cb;
		return this;
	}
	
	public Promise Run()
	{
		var execution = new DynaProCommandExecution(this, _callbacks);
		return execution.Completion;
	}
	
}
