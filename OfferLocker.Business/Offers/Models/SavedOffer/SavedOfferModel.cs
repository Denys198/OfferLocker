﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.SavedOffer
{
    public sealed class SavedOfferModel
    {
        public Guid Id { get; private set; }
        public Guid OfferId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
