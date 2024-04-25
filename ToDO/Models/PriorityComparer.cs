namespace ToDO.Models
{
    public class PriorityComparer : IComparer<ToDo>
    {
      private  bool orderingAscenging;

     

        public PriorityComparer(bool orderingAscenging) {
       this.orderingAscenging = orderingAscenging;
        
        }
        public int Compare(ToDo x, ToDo y)
        {
            Dictionary<string, int> priorityOrder = new Dictionary<string, int>
        {
            {"HIGH", 3},
            {"MEDIUM", 2},
            {"LOW", 1}
        };

            int priorityX = priorityOrder[x.Priority];
            int priorityY = priorityOrder[y.Priority];

            if (orderingAscenging)
            {
                if (priorityX == priorityY)
                {
                    return string.Compare(x.Title, y.Title, StringComparison.Ordinal);
                }
                else
                {
                    return priorityX.CompareTo(priorityY);
                }
            }
            else
            {
                if (priorityX == priorityY)
                {
                    return string.Compare(y.Title, x.Title, StringComparison.Ordinal);
                }
                else
                {
                    return priorityY.CompareTo(priorityX);
                }
            }
        }
    }
}
