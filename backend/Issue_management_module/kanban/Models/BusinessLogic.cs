using Microsoft.EntityFrameworkCore;

namespace Kanban.Models
{
    public class BusinessLogic
    {
        public virtual IEnumerable<Card> GetAllCards()
        {
            using (var context = new DashboardContext(new DbContextOptions<DashboardContext>()))
            {
                var dashboardContext = context.Cards.Include(c => c.State);
                return dashboardContext.ToList();
            }
        }

       public virtual void AddCard(Card card)
{
    using (var context = new DashboardContext(new DbContextOptions<DashboardContext>()))
    {
        card.Id = Guid.NewGuid();
        var state = context.States.FirstOrDefault(s => s.Name == "ToDo");
        if (state != null)
        {
            card.State = state;
        }
        else
        {
            // Handle the case when the state is not found
            // For example, you can throw an exception or set a default state
            // card.State = defaultState;
        }
        context.Add(card);
        context.SaveChanges();
    }
}
        
        public virtual Card GetCard(Guid id)
{
    using (var context = new DashboardContext(new DbContextOptions<DashboardContext>()))
    {
        var card = new Card();
        card.Id = id;
        card.State = context.States.FirstOrDefault(s => s.Name == "ToDo");
        context.Add(card);
        context.SaveChanges();
        return card;
    }
}

        public virtual Card UpdateCard(Card uCard)
        {
            using (var context = new DashboardContext(new DbContextOptions<DashboardContext>()))
            {
                var card = context.Cards.FirstOrDefault(c => c.Id == uCard.Id);
                if (card == null)
                    return null;

                card.Title = uCard.Title;
                card.Description = uCard.Description;
                context.SaveChanges();

                var dashboardContext = context.Cards.Include(c => c.State);
                return dashboardContext.FirstOrDefault(c => c.Id == uCard.Id);
            }
        }

      public virtual Card ChangeStatusCard(Guid id)
{
    using (var context = new DashboardContext(new DbContextOptions<DashboardContext>()))
    {
        var card = context.Cards.Include(c => c.State).SingleOrDefault(m => m.Id == id);
        if (card == null)
            return null;

        card.State = context.States.FirstOrDefault(s => s.Priority == card.State.Priority + 1);
        context.SaveChanges();

        // Return the modified 'card' object directly
        return card;
    }
}


        public virtual Card DeleteCard(Guid id)
        {
            using (var context = new DashboardContext(new DbContextOptions<DashboardContext>()))
            {
                var card = context.Cards.SingleOrDefault(m => m.Id == id);
                if (card == null)
                    return null;

                context.Cards.Remove(card);
                context.SaveChanges();
                return card;
            }
        }

       
    }

}