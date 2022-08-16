# JsonDeserialize
Test for Json Deserialzation depth in C#

When you run the program, set a breakpoint in KboAjaxGenie.RunAjaxGenie at line 20:
Console.WriteLine.

If you compare the contents of the input json to the deserialized _ajaxBookGenieParams,
you'll see that the source json BookGenieParams.SelectedCategories = [37,36]. while _ajaxBookGenieParams.BookGenieParams.SelectedCategories has no children.


