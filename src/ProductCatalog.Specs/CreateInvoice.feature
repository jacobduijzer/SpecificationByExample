Feature: Creating an invoice from a shopping basket

As a customer
I want to review my order before paying
So I know what items I ordered and the amount I have to pay

    Background:
        Given the following books
          | Title                        | Author        | Format    | Price |
          | Specification By Example     | Gojko Adzic   | PFD       | 22.67 |
          | Specification By Example     | Gojko Adzic   | Hardcover | 31.49 |
          | Writing Great Specifications | Kamil Nicieja | epub      | 22.67 |
          | Writing Great Specifications | Kamil Nicieja | Hardcover | 28.34 |
          | Code That Fits In Your Head  | Mark Seemann  | PDF       | 23.99 |
          | Code That Fits In Your Head  | Mark Seemann  | Hardcover | 35.99 |

    Scenario: Ordering digital books only

    Placing an order with digital products only should result in an invoice with no additional cost for shipping.

        Given Simone has a shopping cart with: 'Specification By Example' with format 'PDF'
        And it also contains 'Writing Great Specifications' with format 'epub'
        When she is going to pay her order
        Then she should get an invoice that has the following invoice items
          | Name                                                | Amount | Price | Discount | Total Price |
          | PDF: Specification By Example by Gojko Adzic        | 1x     | 22.67 | 0        | 22.67       |
          | epub: Writing Great Specifications by Kamil Nicieja | 1x     | 22.67 | 0        | 22.67       |

    Scenario: Ordering multiple items of the same book

    Ordering multiple items of the same book should give a different total price (book price times the number of books ordered)

        Given Simone has a shopping cart with 2 copies of 'Specification By Example' with format 'PDF'
        And it also contains 1 copy of 'Writing Great Specifications' with format 'epub'
        When she is going to pay her order
        Then she should get an invoice that has the following invoice items
          | Name                                                | Amount | Price | Discount | Total Price |
          | PDF: Specification By Example by Gojko Adzic        | 2x     | 22.67 | 0        | 45.34       |
          | epub: Writing Great Specifications by Kamil Nicieja | 1x     | 22.67 | 0        | 22.67       |

    Scenario: Ordering hardcover books should add shipping costs

    Placing an order with physical items should add shipping costs to the invoice.

        Given Simone has a shopping cart with: 'Specification By Example' with format 'Hardcover'
        When she is going to pay her order
        Then she should get an invoice that has the following invoice items
          | Name                                               | Amount | Price | Discount | Total Price |
          | Hardcover: Specification By Example by Gojko Adzic | 1x     | 31.49 | 0        | 31.49       |
          | Shipping                                           | 1x     | 5.95  | 0        | 5.95        |

    Scenario: Ordering physical items with a total amount above EUR 100 should result in free shipping

    Placing an order with a total amount above EUR 100 should give free shipping

    ***Free Shipping:***
    ![Shopping Cart Mockup](./src/ProductCatalog.Specs/Assets/shipping_costs.png)

        Given Simone has a shopping cart with 10 copies of 'Specification By Example' with format 'Hardcover'
        When she is going to pay her order
        Then she should get an invoice that has the following invoice items
          | Name                                               | Amount | Price | Discount | Total Price |
          | Hardcover: Specification By Example by Gojko Adzic | 10x    | 31.49 | 0        | 314.90      |
          | Shipping                                           | 1x     | 5.95  | 5.95     | 0           |

    Scenario Outline: Ordering different amounts of books

        Given Simone has a shopping cart with <amount> copies of 'Specification By Example' with format '<format>'
        When she is going to pay her order
        Then the shipping costs should be <shipping costs>

        Examples: Shipping costs
          | format    | amount | shipping costs |
          | Hardcover | 1      | 5.95           |
          | Hardcover | 3      | 5.95           |

        Examples: Free Shipping
          | format    | amount | shipping costs |
          | Hardcover | 4      | 0              |
          | Hardcover | 10     | 0              |

        Examples: No Shipping
          | format    | amount | shipping costs |
          | Hardcover | 0      | 0              |