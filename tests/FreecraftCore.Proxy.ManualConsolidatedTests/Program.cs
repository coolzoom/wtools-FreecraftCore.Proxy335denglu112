﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FreecraftCore.Proxy.ManualConsolidatedTests
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			Task.Factory.StartNew(async () => await FreecraftCore.Auth.Program.Main(null).ConfigureAwait(false), TaskCreationOptions.LongRunning);
			Task.Factory.StartNew(async () => await FreecraftCore.Game.Program.Main(null).ConfigureAwait(false), TaskCreationOptions.LongRunning);

			while(true)
				await Task.Delay(5000)
					.ConfigureAwait(false);
		}
	}
}
