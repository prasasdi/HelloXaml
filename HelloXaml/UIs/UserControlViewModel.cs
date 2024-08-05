using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

    public class UserControlViewModel : INotifyPropertyChanged
    {
        private System.Timers.Timer timer = new System.Timers.Timer(5000);
        #region Messages and SelectedMessage
        private ObservableCollection<MessageModel> messages = new ObservableCollection<MessageModel>();
        public ObservableCollection<MessageModel> Messages { 
            get => messages;
            set
            {
                if (messages != null)
                {
                    messages = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Messages"));
                }
            }
        }
        
        private MessageModel selectedMessage;
        #endregion

        #region NotificationMessage

        private string notificationMessage;
        public string NotificationMessage 
        { 
            get => notificationMessage; 
            set
            {
                if (notificationMessage != value) 
                {
                    notificationMessage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(NotificationMessage)));

                }
            }
        }

        #endregion

        /// <summary>
        /// Selected entity
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #region Command Region

        #region Relays
        public RelayCommand DeleteMessageCommand { get; set; }
        #endregion

        public MessageModel SelectedMessage { 
            get => selectedMessage; 
            set {
                selectedMessage = value;
                DeleteMessageCommand.RaiseCanExecuteChanged();
                //PropertyChanged(this, new PropertyChangedEventArgs("Messages"));
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
            DeleteMessageCommand = new RelayCommand(OnDelete, CanDelete);
            timer.Elapsed += (s, e) => NotificationMessage = "At the tone time will be: " + DateTime.Now.ToLocalTime() + " beep. ";

            timer.Start();
        }

        public void LoadMessagesManually()
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
