using Microsoft.AspNetCore.Mvc;
using ToDO.Models;

namespace ToDO.InterFace
{
    public interface IManager
    {
        List<ToDo> GetListOfTask([FromQuery] string? priority, [FromQuery] string? isComplete);
        string PostToDoItem(ToDo toDo);
        string PutItemToDo(long id, ToDo toDo);
        string DeleteItemToDo(long id);
        List<ToDo> GetOnlyWhatISearch(String str);
        List<ToDo> getAscending();
        List<ToDo> getDescending();




    }
}
