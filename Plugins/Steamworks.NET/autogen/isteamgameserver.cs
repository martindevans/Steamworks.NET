// This file is automatically generated!

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamGameServer {
	//
	// Basic server data.  These properties, if set, must be set before before calling LogOn.  They
	// may not be changed after logged in.
	//
		/// This is called by SteamGameServer_Init, and you will usually not need to call it directly
		public static bool InitGameServer(uint unIP, ushort usGamePort, ushort usQueryPort, uint unFlags, AppId_t nGameAppId, string pchVersionString) {
			return NativeMethods.ISteamGameServer_InitGameServer(unIP, usGamePort, usQueryPort, unFlags, nGameAppId, new InteropHelp.UTF8String(pchVersionString));
		}

		/// Game product identifier.  This is currently used by the master server for version checking purposes.
		/// It's a required field, but will eventually will go away, and the AppID will be used for this purpose.
		public static void SetProduct(string pszProduct) {
			NativeMethods.ISteamGameServer_SetProduct(new InteropHelp.UTF8String(pszProduct));
		}

		/// Description of the game.  This is a required field and is displayed in the steam server browser....for now.
		/// This is a required field, but it will go away eventually, as the data should be determined from the AppID.
		public static void SetGameDescription(string pszGameDescription) {
			NativeMethods.ISteamGameServer_SetGameDescription(new InteropHelp.UTF8String(pszGameDescription));
		}

		/// If your game is a "mod," pass the string that identifies it.  The default is an empty string, meaning
		/// this application is the original game, not a mod.
		///
		/// @see k_cbMaxGameServerGameDir
		public static void SetModDir(string pszModDir) {
			NativeMethods.ISteamGameServer_SetModDir(new InteropHelp.UTF8String(pszModDir));
		}

		/// Is this is a dedicated server?  The default value is false.
		public static void SetDedicatedServer(bool bDedicated) {
			NativeMethods.ISteamGameServer_SetDedicatedServer(bDedicated);
		}

	//
	// Login
	//
		/// Begin process to login to a persistent game server account
		///
		/// You need to register for callbacks to determine the result of this operation.
		/// @see SteamServersConnected_t
		/// @see SteamServerConnectFailure_t
		/// @see SteamServersDisconnected_t
		/// Login to a generic, anonymous account.
		///
		/// Note: in previous versions of the SDK, this was automatically called within SteamGameServer_Init,
		/// but this is no longer the case.
		public static void LogOnAnonymous() {
			NativeMethods.ISteamGameServer_LogOnAnonymous();
		}

		/// Begin process of logging game server out of steam
		public static void LogOff() {
			NativeMethods.ISteamGameServer_LogOff();
		}

		// status functions
		public static bool BLoggedOn() {
			return NativeMethods.ISteamGameServer_BLoggedOn();
		}

		public static bool BSecure() {
			return NativeMethods.ISteamGameServer_BSecure();
		}

		public static CSteamID GetSteamID() {
			return (CSteamID)NativeMethods.ISteamGameServer_GetSteamID();
		}

		/// Returns true if the master server has requested a restart.
		/// Only returns true once per request.
		public static bool WasRestartRequested() {
			return NativeMethods.ISteamGameServer_WasRestartRequested();
		}

	//
	// Server state.  These properties may be changed at any time.
	//
		/// Max player count that will be reported to server browser and client queries
		public static void SetMaxPlayerCount(int cPlayersMax) {
			NativeMethods.ISteamGameServer_SetMaxPlayerCount(cPlayersMax);
		}

		/// Number of bots.  Default value is zero
		public static void SetBotPlayerCount(int cBotplayers) {
			NativeMethods.ISteamGameServer_SetBotPlayerCount(cBotplayers);
		}

		/// Set the name of server as it will appear in the server browser
		///
		/// @see k_cbMaxGameServerName
		public static void SetServerName(string pszServerName) {
			NativeMethods.ISteamGameServer_SetServerName(new InteropHelp.UTF8String(pszServerName));
		}

		/// Set name of map to report in the server browser
		///
		/// @see k_cbMaxGameServerName
		public static void SetMapName(string pszMapName) {
			NativeMethods.ISteamGameServer_SetMapName(new InteropHelp.UTF8String(pszMapName));
		}

		/// Let people know if your server will require a password
		public static void SetPasswordProtected(bool bPasswordProtected) {
			NativeMethods.ISteamGameServer_SetPasswordProtected(bPasswordProtected);
		}

		/// Spectator server.  The default value is zero, meaning the service
		/// is not used.
		public static void SetSpectatorPort(ushort unSpectatorPort) {
			NativeMethods.ISteamGameServer_SetSpectatorPort(unSpectatorPort);
		}

		/// Name of the spectator server.  (Only used if spectator port is nonzero.)
		///
		/// @see k_cbMaxGameServerMapName
		public static void SetSpectatorServerName(string pszSpectatorServerName) {
			NativeMethods.ISteamGameServer_SetSpectatorServerName(new InteropHelp.UTF8String(pszSpectatorServerName));
		}

		/// Call this to clear the whole list of key/values that are sent in rules queries.
		public static void ClearAllKeyValues() {
			NativeMethods.ISteamGameServer_ClearAllKeyValues();
		}

		/// Call this to add/update a key/value pair.
		public static void SetKeyValue(string pKey, string pValue) {
			NativeMethods.ISteamGameServer_SetKeyValue(new InteropHelp.UTF8String(pKey), new InteropHelp.UTF8String(pValue));
		}

		/// Sets a string defining the "gametags" for this server, this is optional, but if it is set
		/// it allows users to filter in the matchmaking/server-browser interfaces based on the value
		///
		/// @see k_cbMaxGameServerTags
		public static void SetGameTags(string pchGameTags) {
			NativeMethods.ISteamGameServer_SetGameTags(new InteropHelp.UTF8String(pchGameTags));
		}

		/// Sets a string defining the "gamedata" for this server, this is optional, but if it is set
		/// it allows users to filter in the matchmaking/server-browser interfaces based on the value
		/// don't set this unless it actually changes, its only uploaded to the master once (when
		/// acknowledged)
		///
		/// @see k_cbMaxGameServerGameData
		public static void SetGameData(string pchGameData) {
			NativeMethods.ISteamGameServer_SetGameData(new InteropHelp.UTF8String(pchGameData));
		}

		/// Region identifier.  This is an optional field, the default value is empty, meaning the "world" region
		public static void SetRegion(string pszRegion) {
			NativeMethods.ISteamGameServer_SetRegion(new InteropHelp.UTF8String(pszRegion));
		}

	//
	// Player list management / authentication
	//
		// Handles receiving a new connection from a Steam user.  This call will ask the Steam
		// servers to validate the users identity, app ownership, and VAC status.  If the Steam servers
		// are off-line, then it will validate the cached ticket itself which will validate app ownership
		// and identity.  The AuthBlob here should be acquired on the game client using SteamUser()->InitiateGameConnection()
		// and must then be sent up to the game server for authentication.
		//
		// Return Value: returns true if the users ticket passes basic checks. pSteamIDUser will contain the Steam ID of this user. pSteamIDUser must NOT be NULL
		// If the call succeeds then you should expect a GSClientApprove_t or GSClientDeny_t callback which will tell you whether authentication
		// for the user has succeeded or failed (the steamid in the callback will match the one returned by this call)
		public static bool SendUserConnectAndAuthenticate(uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, out CSteamID pSteamIDUser) {
			return NativeMethods.ISteamGameServer_SendUserConnectAndAuthenticate(unIPClient, pvAuthBlob, cubAuthBlobSize, out pSteamIDUser);
		}

		// Creates a fake user (ie, a bot) which will be listed as playing on the server, but skips validation.
		//
		// Return Value: Returns a SteamID for the user to be tracked with, you should call HandleUserDisconnect()
		// when this user leaves the server just like you would for a real user.
		public static CSteamID CreateUnauthenticatedUserConnection() {
			return (CSteamID)NativeMethods.ISteamGameServer_CreateUnauthenticatedUserConnection();
		}

		// Should be called whenever a user leaves our game server, this lets Steam internally
		// track which users are currently on which servers for the purposes of preventing a single
		// account being logged into multiple servers, showing who is currently on a server, etc.
		public static void SendUserDisconnect(CSteamID steamIDUser) {
			NativeMethods.ISteamGameServer_SendUserDisconnect(steamIDUser);
		}

		// Update the data to be displayed in the server browser and matchmaking interfaces for a user
		// currently connected to the server.  For regular users you must call this after you receive a
		// GSUserValidationSuccess callback.
		//
		// Return Value: true if successful, false if failure (ie, steamIDUser wasn't for an active player)
		public static bool BUpdateUserData(CSteamID steamIDUser, string pchPlayerName, uint uScore) {
			return NativeMethods.ISteamGameServer_BUpdateUserData(steamIDUser, new InteropHelp.UTF8String(pchPlayerName), uScore);
		}

		// New auth system APIs - do not mix with the old auth system APIs.
		// ----------------------------------------------------------------
		// Retrieve ticket to be sent to the entity who wishes to authenticate you ( using BeginAuthSession API ).
		// pcbTicket retrieves the length of the actual ticket.
		public static HAuthTicket GetAuthSessionTicket(IntPtr pTicket, int cbMaxTicket, out uint pcbTicket) {
			return (HAuthTicket)NativeMethods.ISteamGameServer_GetAuthSessionTicket(pTicket, cbMaxTicket, out pcbTicket);
		}

		// Authenticate ticket ( from GetAuthSessionTicket ) from entity steamID to be sure it is valid and isnt reused
		// Registers for callbacks if the entity goes offline or cancels the ticket ( see ValidateAuthTicketResponse_t callback and EAuthSessionResponse )
		public static EBeginAuthSessionResult BeginAuthSession(IntPtr pAuthTicket, int cbAuthTicket, CSteamID steamID) {
			return NativeMethods.ISteamGameServer_BeginAuthSession(pAuthTicket, cbAuthTicket, steamID);
		}

		// Stop tracking started by BeginAuthSession - called when no longer playing game with this entity
		public static void EndAuthSession(CSteamID steamID) {
			NativeMethods.ISteamGameServer_EndAuthSession(steamID);
		}

		// Cancel auth ticket from GetAuthSessionTicket, called when no longer playing game with the entity you gave the ticket to
		public static void CancelAuthTicket(HAuthTicket hAuthTicket) {
			NativeMethods.ISteamGameServer_CancelAuthTicket(hAuthTicket);
		}

		// After receiving a user's authentication data, and passing it to SendUserConnectAndAuthenticate, use this function
		// to determine if the user owns downloadable content specified by the provided AppID.
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID) {
			return NativeMethods.ISteamGameServer_UserHasLicenseForApp(steamID, appID);
		}

		// Ask if a user in in the specified group, results returns async by GSUserGroupStatus_t
		// returns false if we're not connected to the steam servers and thus cannot ask
		public static bool RequestUserGroupStatus(CSteamID steamIDUser, CSteamID steamIDGroup) {
			return NativeMethods.ISteamGameServer_RequestUserGroupStatus(steamIDUser, steamIDGroup);
		}

		// these two functions s are deprecated, and will not return results
		// they will be removed in a future version of the SDK
		public static void GetGameplayStats() {
			NativeMethods.ISteamGameServer_GetGameplayStats();
		}

		public static SteamAPICall_t GetServerReputation() {
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_GetServerReputation();
		}

		// Returns the public IP of the server according to Steam, useful when the server is
		// behind NAT and you want to advertise its IP in a lobby for other clients to directly
		// connect to
		public static uint GetPublicIP() {
			return NativeMethods.ISteamGameServer_GetPublicIP();
		}

	// These are in GameSocketShare mode, where instead of ISteamGameServer creating its own
	// socket to talk to the master server on, it lets the game use its socket to forward messages
	// back and forth. This prevents us from requiring server ops to open up yet another port
	// in their firewalls.
	//
	// the IP address and port should be in host order, i.e 127.0.0.1 == 0x7f000001
		// These are used when you've elected to multiplex the game server's UDP socket
		// rather than having the master server updater use its own sockets.
		//
		// Source games use this to simplify the job of the server admins, so they
		// don't have to open up more ports on their firewalls.
		// Call this when a packet that starts with 0xFFFFFFFF comes in. That means
		// it's for us.
		public static bool HandleIncomingPacket(IntPtr pData, int cbData, uint srcIP, ushort srcPort) {
			return NativeMethods.ISteamGameServer_HandleIncomingPacket(pData, cbData, srcIP, srcPort);
		}

		// AFTER calling HandleIncomingPacket for any packets that came in that frame, call this.
		// This gets a packet that the master server updater needs to send out on UDP.
		// It returns the length of the packet it wants to send, or 0 if there are no more packets to send.
		// Call this each frame until it returns 0.
		public static int GetNextOutgoingPacket(IntPtr pOut, int cbMaxOut, out uint pNetAdr, out ushort pPort) {
			return NativeMethods.ISteamGameServer_GetNextOutgoingPacket(pOut, cbMaxOut, out pNetAdr, out pPort);
		}

	//
	// Control heartbeats / advertisement with master server
	//
		// Call this as often as you like to tell the master server updater whether or not
		// you want it to be active (default: off).
		public static void EnableHeartbeats(bool bActive) {
			NativeMethods.ISteamGameServer_EnableHeartbeats(bActive);
		}

		// You usually don't need to modify this.
		// Pass -1 to use the default value for iHeartbeatInterval.
		// Some mods change this.
		public static void SetHeartbeatInterval(int iHeartbeatInterval) {
			NativeMethods.ISteamGameServer_SetHeartbeatInterval(iHeartbeatInterval);
		}

		// Force a heartbeat to steam at the next opportunity
		public static void ForceHeartbeat() {
			NativeMethods.ISteamGameServer_ForceHeartbeat();
		}

		// associate this game server with this clan for the purposes of computing player compat
		public static SteamAPICall_t AssociateWithClan(CSteamID steamIDClan) {
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_AssociateWithClan(steamIDClan);
		}

		// ask if any of the current players dont want to play with this new player - or vice versa
		public static SteamAPICall_t ComputeNewPlayerCompatibility(CSteamID steamIDNewPlayer) {
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_ComputeNewPlayerCompatibility(steamIDNewPlayer);
		}
	}
}