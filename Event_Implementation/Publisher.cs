using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Implementation
{
    public delegate void EventHandler(object sender, EventArgs e);
    public class Publisher : ArrayList
    {
        public event EventHandler ProdcutAddedInfo;
        protected virtual void OnChanged(EventArgs e)
        {
            if (ProdcutAddedInfo != null)
                ProdcutAddedInfo(this, e);
        }
        public override int Add(Object product)
        {
           int added = base.Add(product);
            OnChanged(EventArgs.Empty);
            return added;
        }
        public override void Clear()
        {
            base.Clear();
            OnChanged(EventArgs.Empty);
        }

        public override object this[int index]
        {
            set
            {
                base[index] = value;
                OnChanged(EventArgs.Empty);
            }
        }
    }
}
