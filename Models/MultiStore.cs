using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("multistore", Schema = "stage")]
public class MultiStore
{
    public double id { get; set; }
    public string order_id { get; set; }
    public DateOnly order_date { get; set; }
    public DateOnly ship_date { get; set; }
    public string ship_mode { get; set; }
    public string customer_id { get; set; }
    public string customer_name { get; set; }
    public double customer_age { get; set; }
    public string customer_birthday { get; set; }
    public bool customer_state { get; set; }
    public string segment { get; set; }
    public string country { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string regional_manager_id { get; set; }
    public string regional_manager { get; set; }
    public string postal_code { get; set; }
    public string region { get; set; }
    public string product_id { get; set; }
    public string category { get; set; }
    public string sub_category { get; set; }
    public string product_name { get; set; }
    public double sales { get; set; }
    public double quantity { get; set; }
    public double discount { get; set; }
    public double profit { get; set; }
}
