﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Packet.Auth;
using GladNet;
using JetBrains.Annotations;

namespace FreecraftCore
{
	//TODO: Add service/interface/context that allows server handlers to send messages through the client
	public sealed class ProxiedAuthenticationSessionMessageContext : IPeerSessionMessageContext<AuthenticationServerPayload>
	{
		/// <inheritdoc />
		public IConnectionService ConnectionService { get; }

		/// <inheritdoc />
		public IPeerPayloadSendService<AuthenticationServerPayload> PayloadSendService { get; }

		/// <inheritdoc />
		public IPeerRequestSendService<AuthenticationServerPayload> RequestSendService { get; }

		/// <inheritdoc />
		public SessionDetails Details { get; }

		public IManagedNetworkClient<AuthenticationClientPayload, AuthenticationServerPayload> ProxyClient { get; }

		/// <inheritdoc />
		public ProxiedAuthenticationSessionMessageContext([NotNull] IConnectionService connectionService, [NotNull] IPeerPayloadSendService<AuthenticationServerPayload> payloadSendService, 
			[NotNull] IPeerRequestSendService<AuthenticationServerPayload> requestSendService, [NotNull] SessionDetails details, [NotNull] IManagedNetworkClient<AuthenticationClientPayload, AuthenticationServerPayload> proxyClient)
		{
			if(connectionService == null) throw new ArgumentNullException(nameof(connectionService));
			if(payloadSendService == null) throw new ArgumentNullException(nameof(payloadSendService));
			if(requestSendService == null) throw new ArgumentNullException(nameof(requestSendService));
			if(details == null) throw new ArgumentNullException(nameof(details));

			ConnectionService = connectionService;
			PayloadSendService = payloadSendService;
			RequestSendService = requestSendService;
			Details = details;
			ProxyClient = proxyClient ?? throw new ArgumentNullException(nameof(proxyClient));
		}
	}
}
