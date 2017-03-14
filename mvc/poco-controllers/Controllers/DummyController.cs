using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

public class DummyController 
{
    [ActionContext]
    public ActionContext ActionContext { get; set; }

    public IActionResult Get()
    {
        return new ContentResult() { Content = "Hello, I'm a POCO controller" };
    }
}