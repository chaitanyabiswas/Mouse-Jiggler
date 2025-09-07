# *Mouse Jiggler*
#Mouse Jiggler is an application that simulates mouse movements to prevent the computer from going into sleep mode or locking the screen due to inactivity. It is often used by people who need to keep their computer active for long periods of time without interacting with it. Mouse Jiggler can be configured to jiggle the mouse at different intervals.

## *Startup window* 

![Mouse Jiggler](https://user-images.githubusercontent.com/50495096/235360870-f073ca16-b573-4719-81b2-307a0328adf6.png)

## *Active window*
### Enable will enable the mouse juggle to start working, and you can set the time to set the juggling interval.

![Mouse Jiggler, Active mode](https://user-images.githubusercontent.com/50495096/235360927-fb96b543-65b6-48e8-aa90-58baaab0e593.png)

## Background Process
### A notification will be sent to notify you that it is working in the background.
![image](https://user-images.githubusercontent.com/50495096/235361217-6ba15552-d033-41d8-8418-0a868e3abf37.png)

### It can be retrieved again by double-clicking the icon from the notification area.
![Notificatio Area](https://user-images.githubusercontent.com/50495096/235361661-adf6deab-416e-4571-8e10-44877e4818c8.png)

## Build & run (using dotnet CLI)

Open a PowerShell window in the project root (for example: `C:\temp\Git\Mouse-Jiggler`) and run the following commands.

- Restore packages:

```powershell
dotnet restore
```

- Build the solution:

```powershell
dotnet build .\MouseMove.sln
```

- Run the app (from the project folder or specify the project file):

```powershell
dotnet run --project .\MouseMove.vbproj
```

- Publish a release build (produce an executable):

```powershell
dotnet publish .\MouseMove.vbproj -c Release -r win-x64 --self-contained false -o .\publish
```

- Clean build artifacts:

```powershell
dotnet clean
```

Notes:
- Use `-r win-x64` (or `win-x86`) in `dotnet publish` to target a specific runtime.
- If `dotnet` is not found, install the .NET SDK (matching the project's target, e.g., .NET 6) and ensure it's on your PATH.

