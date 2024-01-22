using System;
using Microsoft.AspNetCore.SignalR;

namespace TestSignalR;

public sealed class ComHub : Hub<IComHub> {
	/*
	 1 - {"protocol":"json","version":1}
	 2 - {"arguments":["Hello Guys"],"invocationId":"0","target":"SendMessage","type":1}
	*/
	public override async Task OnConnectedAsync() {
		await Clients.All.RecieveMessage($"{Context.ConnectionId} joined.");
	}

	public async Task SendMessage(string message) {
		await Clients.All.RecieveMessage($"{Context.ConnectionId}: {message}");
	}
}
