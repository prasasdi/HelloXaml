using System;
using System.CodeDom;
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

        #region Commands
        public RelayCommand DeleteCommand { get; set; }
        #endregion

        #region To Delete An Entity
        private MessageModel selectedMessage;
        public MessageModel SelectedMessage { 
            get => selectedMessage; 
            set {
                selectedMessage = value; 
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public void OnDelete()
        {
            //...args to delete dari list of N
            Messages.Remove(SelectedMessage);
        }
        public bool CanDelete() => SelectedMessage != null;
        #endregion

        public UserControlViewModel()
        {
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
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
