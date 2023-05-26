# SignalR notification sample
#
1. Create WebApi
2. Install ```Microsoft.AspNetCore.SignalR.Client``` package
3. Create custom Hub class inherited from Hub
   ```C#
   public class NotificationHub : Hub
   {
      public async Task SendMessage(string message)
      {
         await Clients.All.SendAsync("GetNotification", message);
      }
   }
   ```
4. Add this line of code to Program.cs
   ```C#
   builder.Services.AddSignalR();
   ...
   app.MapHub<NotificationHub>("/notification");
   ```
5. Create controller to send message
   ```C#
   public class NotificationsController : ControllerBase
   {
     private readonly IHubContext<NotificationHub> _hubContext;

     public NotificationsController(IHubContext<NotificationHub> hubContext)
     {
       _hubContext = hubContext;
     }

     [HttpPost]
     public async Task<IActionResult> SendNotification(string notification)
     {
       await _hubContext.Clients.All.SendAsync("GetNotification", notification);
       return Ok("sent!");
     }
   }
   ```
6. Add Cors
   ```C#
   builder.Services.AddCors(cors =>
   {
     cors.AddDefaultPolicy(corsPolicy =>
     {
       corsPolicy.AllowAnyHeader()
          .AllowAnyOrigin()
          .AllowAnyMethod();
     });
   });
   ```
   
# Frontend app
1. Create BlazorWasm app
2. Install ```Microsoft.AspNetCore.SignalR.Client``` package
3. Create notification razor page
    ```C#
    @page "/notification"
    @using Microsoft.AspNetCore.SignalR.Client

    <MudButton OnClick="@(async () => await SendNotification())">Send</MudButton>

    @foreach (var notification in _notifications)
    {
      <p>@notification</p><br>
    }

    @code {
      private readonly List<string> _notifications = new();
      private HubConnection? _hubConnection;

      protected override async Task OnInitializedAsync()
      {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("<API_HOST>/notification")
            .Build();

        _hubConnection.On<string>("GetNotification", (notification) =>
        {
            _notifications.Add(notification);
            InvokeAsync(StateHasChanged);
        });

        await _hubConnection.StartAsync();
      }
      
      private async Task SendNotification()
      {
        if (_hubConnection?.State == HubConnectionState.Connected)
        {
            await _hubConnection.SendAsync("SendMessage", "hello");
        }
      }
    }
   ```