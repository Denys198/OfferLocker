﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.SavedOffer
{
    public sealed class CreateSavedOfferModel
    {
        public Guid OfferId { get; set; }
        public Guid UserId { get; set; }
    }
}
