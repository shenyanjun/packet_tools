using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace packet_tools
{
    class queue
    {
        private Mutex _mutex = new Mutex(false);
        private Queue<scan_handle_data> _queue = new Queue<scan_handle_data>();
        public void push_queue(scan_handle_data d)
        {
            _mutex.WaitOne();
            _queue.Enqueue(d);
            _mutex.ReleaseMutex();
        }
        public scan_handle_data pop_queue()
        {
            scan_handle_data d = null;
            if (_queue.Count > 0)
            {
                _mutex.WaitOne();
                d = _queue.Dequeue();
                _mutex.ReleaseMutex();
            }
            return d;
        }
    }
    public class scan_handle_data
    {
        public int handle;
        public string sn_data;
    }
}
