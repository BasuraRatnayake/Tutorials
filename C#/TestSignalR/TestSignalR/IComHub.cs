using System;
namespace TestSignalR;

public interface IComHub {
	Task RecieveMessage(string message);
}
