using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using HTMLTableSamples.EntityClasses;

namespace HTMLTableSamples
{
  public class ProductController : ApiController
  {
    // GET api/<controller>
    [HttpGet()]
    public IHttpActionResult Get()
    {
      IHttpActionResult ret = null;
      List<Product> list = new List<Product>();

      // NOTE: The following code is to simulate an unhandled exception
      //int x = 0;
      //int y = 10;
      //int z = y / x;

      list = CreateMockData();
      if (list.Count > 0) {
        ret = Ok(list);
      }
      else {
        ret = NotFound();
      }

      return ret;
    }

    #region CreateMockData Method
    private List<Product> CreateMockData()
    {
      List<Product> ret = new List<Product>();

      ret.Add(new Product()
      {
        ProductId = 1,
        ProductName = "Extending Bootstrap with CSS, JavaScript and jQuery",
        IntroductionDate = Convert.ToDateTime("6/11/2015"),
        Url = "http://bit.ly/1SNzc0i"
      });

      ret.Add(new Product()
      {
        ProductId = 2,
        ProductName = "Build your own Bootstrap Business Application Template in MVC",
        IntroductionDate = Convert.ToDateTime("1/29/2015"),
        Url = "http://bit.ly/1I8ZqZg"
      });

      ret.Add(new Product()
      {
        ProductId = 3,
        ProductName = "Building Mobile Web Sites Using Web Forms, Bootstrap, and HTML5",
        IntroductionDate = Convert.ToDateTime("8/28/2014"),
        Url = "http://bit.ly/1J2dcrj"
      });

      return ret;
    }
    #endregion

    // GET api/<controller>/5
    [HttpGet()]
    public IHttpActionResult Get(int id)
    {
      IHttpActionResult ret;
      List<Product> list = new List<Product>();
      Product prod = new Product();

      try {
        // NOTE: The following code is to simulate an unhandled exception
        //int x = 0;
        //int y = 10;
        //int z = y / x;

        list = CreateMockData();
        prod = list.Find(p => p.ProductId == id);
        if (prod == null) {
          ret = NotFound();
        }
        else {
          ret = Ok(prod);
        }
      }
      catch (DivideByZeroException) {
        ret = InternalServerError(
          new Exception("In the Product.Get(id) method a divide by zero was detected. Please check your parameters"));
      }
      catch (Exception ex) {
        // Do some logging here, or whatever you want to do

        // Set return value to 500
        ret = InternalServerError(ex);
      }

      return ret;
    }

    // POST api/<controller>
    [HttpPost()]
    public IHttpActionResult Post(Product product)
    {
      IHttpActionResult ret = null;

      if (Add(product)) {
        ret = Created<Product>(Request.RequestUri +
                                  product.ProductId.ToString(),
                                  product);
      }
      else {
        ret = BadRequest(ValidationMessages);
      }

      return ret;
    }

    private ModelStateDictionary ValidationMessages { get; set; }

    private bool Add(Product product)
    {
      int newId = 0;
      bool ret = false;
      List<Product> list = new List<Product>();

      // Validate Product Data from user
      ret = Validate(product);
      if (ret) {
        list = CreateMockData();
        // Get the last id
        newId = list.Max(p => p.ProductId);
        newId++;
        product.ProductId = newId;
        // Add to list
        list.Add(product);
        ret = true;
      }

      return ret;
    }

    private bool Validate(Product product)
    {
      ValidationMessages = new ModelStateDictionary();

      if (string.IsNullOrWhiteSpace(product.ProductName)) {
        ValidationMessages.AddModelError("ProductName",
          "Product Name must be filled in.");
      }
      if (string.IsNullOrWhiteSpace(product.Url)) {
        ValidationMessages.AddModelError("Url",
          "URL must be filled in.");
      }

      return (ValidationMessages.Count == 0);
    }

    // PUT api/<controller>/5
    [HttpPut()]
    public IHttpActionResult Put(int id, Product product)
    {
      IHttpActionResult ret = null;
      List<Product> list = new List<Product>();
      Product prod = null;

      // First check to see if we can find the product to update
      list = CreateMockData();
      prod = list.Find(p => p.ProductId == id);
      if (prod == null) {
        ret = NotFound();
      }
      else {
        if (Update(product)) {
          ret = Ok(product);
        }
        else {
          ret = BadRequest(ValidationMessages);
        }
      }

      return ret;
    }

    private bool Update(Product product)
    {
      bool ret = false;

      ret = Validate(product);

      // TODO: Write code to update database here

      return ret;
    }

    // DELETE api/<controller>/5
    [HttpDelete()]
    public IHttpActionResult Delete(int id)
    {
      IHttpActionResult ret = null;
      List<Product> list = new List<Product>();
      Product prod = null;

      // First check to see if we can find the product to delete
      list = CreateMockData();
      prod = list.Find(p => p.ProductId == id);
      if (prod == null) {
        ret = NotFound();
      }
      else {
        if (DeleteProduct(id)) {
          ret = Ok(true);
        }
        else {
          ret = InternalServerError();
        }
      }

      return ret;
    }

    private bool DeleteProduct(int id)
    {
      return true;
    }
  }
}