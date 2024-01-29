# Worker-Service-Dotnet7
Worker-Service- Dotnet7


## For Windows 
 - Publish worker service to folder then in CMD
 - Run Command Prompt as Administrator
  ```powershell
  SC CREATE "ServiceName" binpath="path_of_service.exe"
  ```
  
 - example.
  ```powershell
  SC CREATE "UserService" binpath="D:\Publish\WorkerServiceApp.exe"
  ```
 - For Start service
  ```powershell
  sc start ServiceName
  ```
 - For Monitor Service Status
  ```powershell
  sc query ServiceName
  ```

 - Delete Service
  ```powershell
  sc delete ServiceName
  ```

  







