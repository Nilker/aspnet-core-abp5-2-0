using System.Collections.Generic;
using Abp;
using Abp.RealTime;
using XyAuto.It.Friendships;

namespace XyAuto.It.Chat
{
    public interface IChatCommunicator
    {
        void SendMessageToClient(IReadOnlyList<IOnlineClient> clients, ChatMessage message);

        void SendFriendshipRequestToClient(IReadOnlyList<IOnlineClient> clients, Friendship friend, bool isOwnRequest, bool isFriendOnline);

        void SendUserConnectionChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user, bool isConnected);

        void SendUserStateChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user, FriendshipState newState);

        void SendAllUnreadMessagesOfUserReadToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user);

        void SendReadStateChangeToClients(IReadOnlyList<IOnlineClient> onlineFriendClients, UserIdentifier user);
    }
}

