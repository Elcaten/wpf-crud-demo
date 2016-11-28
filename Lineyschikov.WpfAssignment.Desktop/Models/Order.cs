namespace Lineyschikov.WpfAssignment.Desktop.Models
{
    public class Order : Entity
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            set { SetAndNotify(ref _description, value); }
        }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}