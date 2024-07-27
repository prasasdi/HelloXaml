using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloXaml.UIs
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Epoch { get; set; }
    }

    public class UserControlViewModel
    {
        public ObservableCollection<MessageModel> Messages { get; set; }

        public UserControlViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Messages.Add(new MessageModel
            {
                Id = Guid.NewGuid(),
                Message = "A",
                Epoch = "A"
            });
            Messages.Add(new MessageModel
            {
                Id = Guid.NewGuid(),
                Message = "A",
                Epoch = "A"
            });
            Messages.Add(new MessageModel
            {
                Id = Guid.NewGuid(),
                Message = "A",
                Epoch = "A"
            });
        }
    }
}
