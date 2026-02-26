# Unity Editor Console Logger

**`LogDumpOnStop.cs`** — An Editor-only script that automatically dumps all Unity Console logs to a `.txt` file the moment you stop Play Mode.

---

## Why This Exists

When **vibe coding** — writing code with the help of AI tools — a common bottleneck is the feedback loop between runtime errors and the AI that needs to fix them:

1. You hit Play, something breaks
2. The console fills up with errors
3. You try to describe the problem to the AI — or manually copy-paste logs
4. The AI guesses, fixes the wrong thing, and the cycle repeats

This script removes that friction. When you stop Play Mode, every log entry (errors, warnings, messages) is written to `Logs/runtime_log.txt` automatically. You just open the file and paste it straight into your AI chat. No manual copying, no missing logs, no context lost.

---

## How It Works

- Hooks into `EditorApplication.playModeStateChanged`
- Triggers on `ExitingPlayMode`
- Reads all entries from Unity's internal console via reflection
- Writes them to `<ProjectRoot>/Logs/runtime_log.txt`

Uses reflection to stay compatible across Unity versions — no public API, no package dependency.

---

## Usage

1. Copy `LogDumpOnStop.cs` into any `Editor` folder inside your Unity project's `Assets` directory
2. Hit Play, reproduce your issue, then stop Play Mode
3. The log file is automatically created at:
   ```
   <YourProjectName>/Logs/runtime_log.txt
   ```
4. Hand it off to your AI tool — either paste the file contents directly or attach the file if your AI supports file uploads

That's it. No setup, no configuration.

---

## Output Format

```
[12:43:23.022] 8406016: DemoSimpleLog: OnEnable called.
[12:43:23.025] 8406016: DemoLogBootstrap created demo logger object.
[12:43:23.025] 12714240: InvalidOperationException: You are trying to read Input using the UnityEngine.Input class, but you have switched active Input handling to Input System package in Player Settings.
[12:43:23.025] 8405504: DemoWarningErrorLog: This is a warning sample.
[12:43:23.025] 8405248: DemoWarningErrorLog: This is an error sample.
```

Each line follows the pattern `[timestamp] <mode>: <message>`. The mode value is Unity's internal log flags integer.

---

## Compatibility

| Unity Version | Status |
|---|---|
| Unity 2022 LTS | Tested |
| Unity 6 | Tested |

---

## Limitations

- Only captures **Play Mode** logs — compile errors and Editor-time logs are not included
- The timestamp reflects when the dump runs, not the exact moment each log was created
- Requires the script to be inside an `Editor` folder (it is Editor-only code)
