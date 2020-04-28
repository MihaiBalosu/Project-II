using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Exceptions
{
    public class ProducerException : Exception
    {
        public Guid producerId { get; private set; }

        public ProducerException(Guid producerID) : base($"Producer with id {producerID} was not found!")
        {
            producerId = producerID;
        }
    }
}
