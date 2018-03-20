﻿namespace ClashRoyale.Messages.Client.Scoring
{
    using ClashRoyale.Enums;
    using ClashRoyale.Extensions;
    using ClashRoyale.Maths;

    public class AskForAvatarLocalRankingListMessage : Message
    {
        /// <summary>
        /// Gets the identifier of this message.
        /// </summary>
        public override short Identifier
        {
            get
            {
                return 14404;
            }
        }

        /// <summary>
        /// Gets the service node of this message.
        /// </summary>
        public override Node ServiceNode
        {
            get
            {
                return Node.Scoring;
            }
        }

        public LogicLong PlayerId;

        /// <summary>
        /// Initializes a new instance of the <see cref="AskForAvatarLocalRankingListMessage"/> class.
        /// </summary>
        public AskForAvatarLocalRankingListMessage()
        {
            // AskForAvatarLocalRankingListMessage.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AskForAvatarLocalRankingListMessage"/> class.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public AskForAvatarLocalRankingListMessage(ByteStream Stream) : base(Stream)
        {
            // AskForAvatarLocalRankingListMessage.
        }

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public override void Decode()
        {
            this.Stream.ReadBoolean();

            if (this.Stream.ReadBoolean())
            {
                this.PlayerId = this.Stream.ReadLong();
            }
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public override void Encode()
        {
            this.Stream.WriteBoolean(false);
            this.Stream.WriteBoolean(!this.PlayerId.IsZero);

            if (!this.PlayerId.IsZero)
            {
                this.Stream.WriteLong(this.PlayerId);
            }
        }
    }
}