

# BlackPianoAssessment

A Blazor WebAssembly Hosted application comprising three projects:

* **Client**: The Blazor WebAssembly front-end.
* **Server**: The ASP.NET Core back-end API.
* **Shared**: Shared models and services between Client and Server.

## 🛠️ Technologies Used

* [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Blazor WebAssembly
* ASP.NET Core
* C#

## 📁 Project Structure

```
BlackPianoAssessment/
├── Client/   # Blazor WebAssembly front-end
├── Server/   # ASP.NET Core back-end API
├── Shared/   # Shared models and services
├── MyBlazorApp.sln
└── README.md
```

## 🚀 Getting Started

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Running the Application

1. **Clone the repository:**

   ```bash
   git clone https://github.com/cvam29/BlackPianoAssesment.git
   cd BlackPianoAssesment
   ```

2. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

3. **Run the application:**

   ```bash
   dotnet run --project Server
   ```

   This will start both the server and the client applications.

4. **Access the application:**

   Navigate to `https://localhost:7096` in your browser.

## 📦 Deployment

To deploy the application:

1. **Publish the Client project:**

   ```bash
   dotnet publish Client/Client.csproj -c Release -o release/wwwroot
   ```

2. **Serve the contents of the `release/wwwroot` directory** using a static file server or integrate it with your preferred hosting solution.



