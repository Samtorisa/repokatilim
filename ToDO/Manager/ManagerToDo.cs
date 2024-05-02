using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDO.Data;
using ToDO.InterFace;
using ToDO.Models;

namespace ToDO.Manager
{
    public class ManagerToDo : IManager
    {
        private readonly StajyertestContext stj;

        public ManagerToDo(StajyertestContext stj) {
            this.stj = stj; 
        }
       // StajyertestContext stj = new StajyertestContext();
       public List<ToDo> GetListOfTask([FromQuery] string? priority, [FromQuery] string? isComplete)
        {
            IQueryable<ToDo> datas = stj.ToDos;

            if (!string.IsNullOrEmpty(priority))
            {
                var priorities = priority.Split(',').Select(p => p.Trim()).ToList();

                datas = datas.Where(p => priorities.Contains(p.Priority.ToString()));
            }
            if (!string.IsNullOrEmpty(isComplete))
            {
                var isCompletees = isComplete.Split(',').Select(s => s.Trim()).ToList();
                datas = datas.Where(s => isCompletees.Contains(s.isComplete.ToString()));
            }
            var tasks = datas.ToList();
            return tasks;
        }
       public string PostToDoItem(ToDo toDo)
        {
            if ((toDo.Priority == "HIGH" || toDo.Priority == "MEDIUM" || toDo.Priority == "LOW")
               && toDo.isComplete == "BEING" ||
               toDo.isComplete == "STARTED" ||
               toDo.isComplete == "COMPLETED")
            {
                ToDo toDoNew = new ToDo();
                toDoNew.Title = toDo.Title.ToLower();
                toDoNew.Priority = toDo.Priority;
                toDoNew.Content = toDo.Content.ToLower();
                toDoNew.isComplete = toDo.isComplete;

                stj.ToDos.Add(toDoNew);
                stj.SaveChanges();
                return "Başarı ile oluşturuldu";
            }
            return " istek de bir yanlışlık var";
        }
        public string PutItemToDo(long id, ToDo toDo)
        {

            ToDo newToDo = stj.ToDos.FirstOrDefault(i => i.id == id);
            newToDo.Title = toDo.Title;
            newToDo.isComplete = toDo.isComplete;
            newToDo.Priority = toDo.Priority;

            try
            {
                stj.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return "Basarili bir sekilde degistirilmisir";
        }
        public string DeleteItemToDo(long id)
        {
            var wasRemove = stj.ToDos.Find(id);

            if (wasRemove == null)
            {
                return "Böyle bir kullanıcı bulunamadı";
            }
            stj.ToDos.Remove(wasRemove);
            stj.SaveChanges();
            return "Kullanici basarili bir sekilde silindi";
        }
        public List<ToDo> GetOnlyWhatISearch(String str)
        {
            var data = stj.ToDos.Where(T => T.Title.Contains(str.ToLower())).ToList();
            return data;
        }
        public List<ToDo> getAscending()
        {
            // var data =stj.ToDos.OrderBy(T => T.Priority).ToList();
            var objects = stj.ToDos.ToList();
            objects.Sort(new PriorityComparer(true));

            return objects;
        }
        public List<ToDo> getDescending()
        {

            //var data = stj.ToDos.OrderByDescending(T => T.Priority).ToList();
            var objects = stj.ToDos.ToList();
            objects.Sort(new PriorityComparer(false));
            return objects;
        }


    }
}
