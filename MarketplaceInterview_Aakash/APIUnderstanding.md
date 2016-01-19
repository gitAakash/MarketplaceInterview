# Api Comparision

### Reebonze Korea App Api

From the doc given we can the productList according to brands and categories.
We also get other data such as,


##### Brand list

Sample Parameter : Null
Sample Response : 
```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"indexes_of_url": [
			["A", "B", "C", "D"],
			["E", "F", "G", "H"],
			["I", "J", "K", "L"],
			["M", "N", "O", "P"],
			["R", "S", "T", "U"],
			["V", "W", "Y", "Z"],
			["_numeric_"]
		],
		"indexes_of_numeric": ["3", "7"],
		"brands": [{
			"url": "3-dot-1-phillip-lim",
			"name": "3.1 Phillip Lim "
		}]
	}

}
```
From this above response we have c# class as.

```javascript
public class Brand
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Data
    {
        public IList<IList<string>> indexes_of_url { get; set; }
        public IList<string> indexes_of_numeric { get; set; }
        public IList<Brand> brands { get; set; }
    }

    public class Example
    {
        public string result { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

```

##### Brand product list

Sample Parameter : UNKOWN

Sample Response : 

```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"filter": {
			"all_category_names": ["BAG", "CLOTHES", "SHOES", "WALLET"],
			"all_gender": ["Women", "Men"],
			"all_brand_names": null,
			"price_groups": [false, true, true, true, false],
			"price_groups_title": ["~10\ub9cc\uc6d0", "300\ub9cc\uc6d0~",
				"Dix",
				"Padlock",
				"Papier"
			],
			"vintage_product_request": null
		},
		"event": null,
		"products": {
			"product": [{
				"id": 718755,
				"name": "Saint Laurent Y Line Zip Around Wallet",
				"image_representative": {
					"filename": {
						"url": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201505/683208/thumb_235_201322815387_314991BJ50J1000_120150520-8333-1x2ov9s.jpg"
					}
				},
				"is_overseas": false,
				"current_quantity": 4,
				"closet_request": null,
				"is_vintage": false,
				"has_downloadable_coupon": false,
				"discount_amount_to_s": "",
				"brand_name": "Saint Laurent ",
				" name_without_brand ": "Wallet",
				"price_with_coupon": 799000,
				"selling_price": 799000,
				"available_event_id": 1
			}]
		}
	}
}
```
From this above response we have c# class as.

```javascript
public class Filter
    {
        public IList<string> all_category_names { get; set; }
        public IList<string> all_gender { get; set; }
        public object all_brand_names { get; set; }
        public IList<bool> price_groups { get; set; }
        public IList<string> price_groups_title { get; set; }
        public object vintage_product_request { get; set; }
    }

    public class Filename
    {
        public string url { get; set; }
    }

    public class ImageRepresentative
    {
        public Filename filename { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public ImageRepresentative image_representative { get; set; }
        public bool is_overseas { get; set; }
        public int current_quantity { get; set; }
        public object closet_request { get; set; }
        public bool is_vintage { get; set; }
        public bool has_downloadable_coupon { get; set; }
        public string discount_amount_to_s { get; set; }
        public string brand_name { get; set; }
        public string  name_without_brand  { get; set; }
        public int price_with_coupon { get; set; }
        public int selling_price { get; set; }
        public int available_event_id { get; set; }
    }

    public class Products
    {
        public IList<Product> product { get; set; }
    }

    public class Data
    {
        public Filter filter { get; set; }
        public object event { get; set; }
        public Products products { get; set; }
    }

    public class Example
    {
        public string result { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

```
##### Meta-brand products list
Sample Parameter : NOT CLEAR

Sample Response : 
```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"filter": {
			"all_category_names": ["BAG", "WALLET", "SHOES", "CLOTHES", "ACC"],
			"all_gender": ["Men", "Women"],
			"all_brand_names": null,
			"price_groups": null,
			"price_groups_title": ["~10\ub9cc\uc6d0", "300\ub9cc\uc6d0~ ",
				"Dix",
				"Maillon",
				"Padlock",
				"Papier",
				"Pompon"
			],
			"vintage_product_request": null
		},
		"event": null,
		"product_meta_info": {
			"product_meta_info": [{
				"product": {
					"id": 647736,
					"name": "Balenciaga Classic City Bag",
					"image_representative": {
						"filename": {
							"url": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201505/691140/thumb_235_115748D94JT1000_1a20150526-16856-kzv5ml.jpg"
						}
					},
					"is_overseas": false,
					"current_quantity": 3,
					"closet_request": null,
					"is_vintage": false,
					"has_downloadable_coupon": false,
					"discount_amount_to_s": "",
					"brand_name": "Balenciaga",
					"name_without_brand": "Classic City Bag ",
					" name_without_vintage ": "Bag",
					"price_with_coupon": 1799000,
					"selling_price": 1799000,
					"available_event_id": 1
				},
				"id": 691140,
				"name": "Balenciaga Classic City Bag",
				"img_representative": {
					"filename": {
						"url": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201505/691140/thumb_235_115748D94JT1000_1a20150526-16856-kzv5ml.jpg"
					}
				},
				"brand_name": "Balenciaga",
				"name_without_brand": "Classic City Bag "
			}]
		}
	}
}
```
From this above response we have c# class as.

```javascript
 public class Filter
    {
        public IList<string> all_category_names { get; set; }
        public IList<string> all_gender { get; set; }
        public object all_brand_names { get; set; }
        public object price_groups { get; set; }
        public IList<string> price_groups_title { get; set; }
        public object vintage_product_request { get; set; }
    }

    public class Filename
    {
        public string url { get; set; }
    }

    public class ImageRepresentative
    {
        public Filename filename { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public ImageRepresentative image_representative { get; set; }
        public bool is_overseas { get; set; }
        public int current_quantity { get; set; }
        public object closet_request { get; set; }
        public bool is_vintage { get; set; }
        public bool has_downloadable_coupon { get; set; }
        public string discount_amount_to_s { get; set; }
        public string brand_name { get; set; }
        public string name_without_brand { get; set; }
        public string  name_without_vintage  { get; set; }
        public int price_with_coupon { get; set; }
        public int selling_price { get; set; }
        public int available_event_id { get; set; }
    }

    public class ImgRepresentative
    {
        public  filename { get; set; }
    }

    public class ProductMetaInfo
    {
        public Product product { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public ImgRepresentative img_representative { get; set; }
        public string brand_name { get; set; }
        public string name_without_brand { get; set; }
    }

    public class ProductMetaInfo
    {
        public IList<ProductMetaInfo> product_meta_info { get; set; }
    }

    public class Data
    {
        public Filter filter { get; set; }
        public object event { get; set; }
        public ProductMetaInfo product_meta_info { get; set; }
    }

    public class Example
    {
        public string result { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    
```
##### Brand line-up list Query

Sample Parameter : NOT KNOWN

Sample Response : 
```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"brand_line_up": [{
			"id": 83,
			"name": "Camouflage"
		}, {
			"id": 84,
			"name": "Rockstud"
		}]
	}
}

```
From this above response we have c# class as.
```javascript
public class BrandLineUp
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Data
    {
        [JsonProperty("brand_line_up")]
        public IList<BrandLineUp> brand_line_up { get; set; }
    }

    public class Example
    {
        [JsonProperty("result")]
        public string result { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public Data data { get; set; }
    }

```

##### Product Details

Sample Parameter : {“event_id”:”123”}
                    event_id=123
Sample Response : 

```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"event": {
			"id": 14003,
			"sale_end_at": "2015-12-15T11:00:00+09:00"
		},
		"product": {
			"id": 294753,
			"product_meta_info_id": 275000,
			"image_representative": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201406/275000/F1_2013_Korea_GP978.jpg",
			"image_details": [{
				"filename_url": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201406/275000/F1_2013_Korea_GP978.jpg",
				"thumb_235_url": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201406/275000/thumb_235_F1_2013_Korea_GP978.jpg"
			}],
			"description": "",
			"size_info": "",
			"tip": null,
			"legal_info": "",
			"total_quantity": 1,
			"current_quantity": 1,
			"is_overseas": false,
			"brand_id": 637,
			"brand_name": "Piajet",
			"brand_url": "piajet",
			"brand_line_up_name": null,
			"brand_country": "Switzerland",
			"name_without_brand": "Possession Ring",
			"is_vintage": true,
			"grade": "clean",
			"price_with_coupon": 1439000,
			"downloadable_coupon_id": "",
			"discount_amount_to_s": "",
			"selling_price": 1439000,
			"blank_code": "CC1406-AC00029",
			"color": "Gold",
			"material": "18K YG",
			"delivery_type": "",
			"has_default_option": true,
			"has_default_option_stock_name": "\uc635\uc158\uc5c6\uc74c:\uc635\uc158\uc5c6\uc74c",
			"options": [{
				"option": [
					["\uc120\ud0dd\ud558\uc138\uc694", null],
					["\uc635\uc158\uc5c6\uc74c", "\uc635\uc158\uc5c6\uc74c:\uc635\uc158\uc5c6\uc74c"]
				]
			}],
			"stocks": [{
				"id": 380478,
				"name": "",
				"ordered_count": 0,
				"stock_count": 1
			}],
			"order_count_limit": 0,
			"other_product": {
				"id": "294753",
				"event_id": "14003"
			},
			"comments": null
		},
		"current_user": null
	}
}
```
From this above response we have c# class as.
```javascript
  public class Event
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("sale_end_at")]
        public DateTime sale_end_at { get; set; }
    }

    public class ImageDetail
    {
        [JsonProperty("filename_url")]
        public string filename_url { get; set; }
        [JsonProperty("thumb_235_url")]
        public string thumb_235_url { get; set; }
    }

    public class Option
    {
        [JsonProperty("option")]
        public IList<IList<string>> option { get; set; }
    }

    public class Stock
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("ordered_count")]
        public int ordered_count { get; set; }
        [JsonProperty("stock_count")]
        public int stock_count { get; set; }
    }

    public class OtherProduct
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("event_id")]
        public string event_id { get; set; }
    }

    public class Product
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("product_meta_info_id")]
        public int product_meta_info_id { get; set; }
        [JsonProperty("image_representative")]
        public string image_representative { get; set; }
        [JsonProperty("image_details")]
        public IList<ImageDetail> image_details { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("size_info")]
        public string size_info { get; set; }
        [JsonProperty("tip")]
        public object tip { get; set; }
        [JsonProperty("legal_info")]
        public string legal_info { get; set; }
        [JsonProperty("total_quantity")]
        public int total_quantity { get; set; }
        [JsonProperty("current_quantity")]
        public int current_quantity { get; set; }
        [JsonProperty("is_overseas")]
        public bool is_overseas { get; set; }
        [JsonProperty("brand_id")]
        public int brand_id { get; set; }
        [JsonProperty("brand_name")]
        public string brand_name { get; set; }
        [JsonProperty("brand_url")]
        public string brand_url { get; set; }
        [JsonProperty("brand_line_up_name")]
        public object brand_line_up_name { get; set; }
        [JsonProperty("brand_country")]
        public string brand_country { get; set; }
        [JsonProperty("name_without_brand")]
        public string name_without_brand { get; set; }
        [JsonProperty("is_vintage")]
        public bool is_vintage { get; set; }
        [JsonProperty("grade")]
        public string grade { get; set; }
        [JsonProperty("price_with_coupon")]
        public int price_with_coupon { get; set; }
        [JsonProperty("downloadable_coupon_id")]
        public string downloadable_coupon_id { get; set; }
        [JsonProperty("discount_amount_to_s")]
        public string discount_amount_to_s { get; set; }
        [JsonProperty("selling_price")]
        public int selling_price { get; set; }
        [JsonProperty("blank_code")]
        public string blank_code { get; set; }
        [JsonProperty("color")]
        public string color { get; set; }
        [JsonProperty("material")]
        public string material { get; set; }
        [JsonProperty("delivery_type")]
        public string delivery_type { get; set; }
        [JsonProperty("has_default_option")]
        public bool has_default_option { get; set; }
        [JsonProperty("has_default_option_stock_name")]
        public string has_default_option_stock_name { get; set; }
        [JsonProperty("options")]
        public IList<Option> options { get; set; }
        [JsonProperty("stocks")]
        public IList<Stock> stocks { get; set; }
        [JsonProperty("order_count_limit")]
        public int order_count_limit { get; set; }
        [JsonProperty("other_product")]
        public OtherProduct other_product { get; set; }
        [JsonProperty("comments")]
        public object comments { get; set; }
    }

    public class Data
    {
        [JsonProperty("event")]
        public Event event { get; set; }
        [JsonProperty("product")]
        public Product product { get; set; }
        [JsonProperty("current_user")]
        public object current_user { get; set; }
    }

    public class Example
    {
        [JsonProperty("result")]
        public string result { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public Data data { get; set; }
    }

```

##### Product lookup

Sample Parameter : 
                     {“search_words”:”???”}
search_words=???
alternative_search_words : Instead of the following searches search
recommended_search_words: Suggested
brands: Brands Featuredpage

Sample Response : 

```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"search_words": "\ud504\ub77c\ub2e4",
		"products": {
			"product": [{
				"id": 818062,
				"name": "Prada Saffiano Lux Galleria Shopping Bag",
				"image_representative": {
					"filename": {
						"url": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201507/709625/thumb_235_201571014926_1BA863NZVF00020001G_120150720-12079-saedyz.jpg"
					}
				},
				"is_overseas": false,
				"current_quantity": 0,
				"closet_request": null,
				"is_vintage": false,
				"has_downloadable_coupon": false,
				"discount_amount_to_s": "",
				"brand_name": "PRADA",
				"name_without_brand": "Saffiano Lux Galleria Shopping Bag ",
				"name_without_vintageBag": "",
				"price_with_coupon": 1999000,
				"selling_price": 1999000,
				"available_event_id": 1
			}]
		},
		"alternative_search_words": null,
		"brands": null,
		"recommended_search_words": null,
		"page": {
			"total_entries": 2042,
			"per_page": 1,
			"current_page": 1
		}
	}
}
```
From this above response we have c# class as.

```javascript

public class Filename
    {
        [JsonProperty("url")]
        public string url { get; set; }
    }

    public class ImageRepresentative
    {
        [JsonProperty("filename")]
        public Filename filename { get; set; }
    }

    public class Product
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("image_representative")]
        public ImageRepresentative image_representative { get; set; }
        [JsonProperty("is_overseas")]
        public bool is_overseas { get; set; }
        [JsonProperty("current_quantity")]
        public int current_quantity { get; set; }
        [JsonProperty("closet_request")]
        public object closet_request { get; set; }
        [JsonProperty("is_vintage")]
        public bool is_vintage { get; set; }
        [JsonProperty("has_downloadable_coupon")]
        public bool has_downloadable_coupon { get; set; }
        [JsonProperty("discount_amount_to_s")]
        public string discount_amount_to_s { get; set; }
        [JsonProperty("brand_name")]
        public string brand_name { get; set; }
        [JsonProperty("name_without_brand")]
        public string name_without_brand { get; set; }
        [JsonProperty("name_without_vintageBag")]
        public string name_without_vintageBag { get; set; }
        [JsonProperty("price_with_coupon")]
        public int price_with_coupon { get; set; }
        [JsonProperty("selling_price")]
        public int selling_price { get; set; }
        [JsonProperty("available_event_id")]
        public int available_event_id { get; set; }
    }

    public class Products
    {
        [JsonProperty("product")]
        public IList<Product> product { get; set; }
    }

    public class Page
    {
        [JsonProperty("total_entries")]
        public int total_entries { get; set; }
        [JsonProperty("per_page")]
        public int per_page { get; set; }
        [JsonProperty("current_page")]
        public int current_page { get; set; }
    }

    public class Data
    {
        [JsonProperty("search_words")]
        public string search_words { get; set; }
        [JsonProperty("products")]
        public Products products { get; set; }
        [JsonProperty("alternative_search_words")]
        public object alternative_search_words { get; set; }
        [JsonProperty("brands")]
        public object brands { get; set; }
        [JsonProperty("recommended_search_words")]
        public object recommended_search_words { get; set; }
        [JsonProperty("page")]
        public Page page { get; set; }
    }

    public class Example
    {
        [JsonProperty("result")]
        public string result { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public Data data { get; set; }
    }
```




##### Categories list details inquiry

Sample Parameter : {"category_id":1}
                   category_id=1

Sample Response : 
```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"categories": [{
			"id": 2,
			"name": "\ub0a8\uc131"
		}, {
			"id": 3,
			"name": "\uc5ec\uc131"
		}, {
			"id": 64,
			"name": "\uc720\uc544"
		}]
	}
}
```
From this above response we have c# class as.

```javascript
 public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Data
    {
        public IList<Category> categories { get; set; }
    }

    public class Example
    {
        public string result { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

```


##### List LookupSegmentEvents  Women, Men

Sample Parameter : segment_name=men

Sample Response : 



```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"banners_mobile_site_main_top": [],
		"events": [],
		"segment_name": "men",
		"categories": [{
			"category": "bag",
			"url": "http://localhost:3000/assets/mobile/category_banner/category_banner_bag_men_4.png"
		}, {
			"category": "clothes",
			"url": "http://localhost:3000/assets/mobile/category_banner/category_banner_clothes_men_4.png"
		}, {
			"category": "shoes",
			"url": "http://localhost:3000/assets/mobile/category_banner/category_banner_shoes_men_4.png"
		}, {
			"category": "wallet",
			"url": "http://localhost:3000/assets/mobile/category_banner/category_banner_wallet_men_4.png"
		}, {
			"category": "acc",
			"url": "http://localhost:3000/assets/mobile/category_banner/category_banner_acc_men_4.png"
		}, {
			"category": "outlet",
			"url": "http://localhost:3000/assets/mobile/category_banner/category_banner_outlet_men_4.png"
		}]
	}
}
```
From this above response we have c# class as.
```javascript
 public class Category
    {
        public string category { get; set; }
        public string url { get; set; }
    }

    public class Data
    {
        public IList<object> banners_mobile_site_main_top { get; set; }
        public IList<object> events { get; set; }
        public string segment_name { get; set; }
        public IList<Category> categories { get; set; }
    }

    public class Example
    {
        public string result { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

```

##### API Product lookup list by category :  Product List by Category

Sample Response :

```javascript
{
	"result": "success",
	"message": "ok",
	"data": {
		"filter": {
			"all_category_names": null,
			"all_gender": ["men", "women"],
			"all_brand_names": ["Alexander McQueen ", " Proenza Schouler ",
				"Vivienne Westwood ",
				"Zanellato "


			],
			"all_brand_line_up_names": null,
			"vintage_product_request": null
		},
		"event": null,
		"products": {
			"product": [{
				"id": 718755,
				"name": "Saint Laurent Y Line Zip Around Wallet",
				"image_representative": {
					"filename": {
						"url": "https://d8fbeik057xw1.cloudfront.net/uploads/product_meta_info/201505/683208/thumb_235_201322815387_314991BJ50J1000_120150520-8333-1x2ov9s.jpg"
					}
				},
				"is_overseas": false,
				"current_quantity": 4,
				"closet_request": null,
				"is_vintage": false,
				"has_downloadable_coupon": false,
				"discount_amount_to_s": "",
				"brand_name": "Saint Laurent ",
				" name_without_brand ": "Wallet",
				"price_with_coupon": 799000,
				"selling_price": 799000,
				"available_event_id": 1
			}]
		},
		"page": {
			"total_entries": 1105,
			"per_page": 1,
			"current_page": 1
		}
	}
}
```
From this above response we have c# class as.
```javascript
public class Filter
    {
        public object all_category_names { get; set; }
        public IList<string> all_gender { get; set; }
        public IList<string> all_brand_names { get; set; }
        public object all_brand_line_up_names { get; set; }
        public object vintage_product_request { get; set; }
    }

    public class Filename
    {
        public string url { get; set; }
    }

    public class ImageRepresentative
    {
        public Filename filename { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public ImageRepresentative image_representative { get; set; }
        public bool is_overseas { get; set; }
        public int current_quantity { get; set; }
        public object closet_request { get; set; }
        public bool is_vintage { get; set; }
        public bool has_downloadable_coupon { get; set; }
        public string discount_amount_to_s { get; set; }
        public string brand_name { get; set; }
        public string  name_without_brand  { get; set; }
        public int price_with_coupon { get; set; }
        public int selling_price { get; set; }
        public int available_event_id { get; set; }
    }

    public class Products
    {
        public IList<Product> product { get; set; }
    }

    public class Page
    {
        public int total_entries { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
    }

    public class Data
    {
        public Filter filter { get; set; }
        public object event { get; set; }
        public Products products { get; set; }
        public Page page { get; set; }
    }

    public class Example
    {
        public string result { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
```
