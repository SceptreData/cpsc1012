using System;

namespace CorePortfolio2
{
    /*
     * Purpose: To determine the amount of materials and cost required to 
     *          build a playground fence. But this time, we implement a menu
     *          system so that we can re-enter values and see different results.
     *          
     * Input: Rectangular Playground dimensions (in Feet):
     *          - fenceLength
     *          - fenceWidth
     *          - fenceHeight
     *        Gate Dimensions
     *          - gateWidth
     *          - gateHeight
     *        Distance between Posts (in Feet)
     *          - postDistance
     *        Paint Type
     *          -Spruce
     *          -Cedar
     *          -ChainLink
     *         
     * Process:
     *          - totalPerimeter;
     *          - fencePerimeter;
     *          - fenceSqFt;
     *          - fencePricePerSqFt;
     *          - fenceMaterial;
     *          - fenceCost;
     *
     *          - numPosts;
     *          - postCost;
     *
     *          - feetOfRailing;
     *          - railMaterial;
     *          - railPricePerFoot;
     *          - railCost;
     *
     *          - paintPricePerBucket
     *          - sqFtPaintPerQuart
     *          - quartsOfPaint;
     *          - numPaintBuckets;
     *          - paintCost;
     *
     *          - gateMaterial;
     *          - gateCost;
     *
     *          - netPrice;
     *          - taxAmount;
     *          - totalPrice; 
     * 
     *          
     * Output:  Amount of Fencing Material required and Extended Price
     *          Number of Posts required and extended price
     *          Lineal feet of railing required
     *          Amount of paint required and extended price
     *          Number of gates required and extended price
     *          Net Price
     *          Total GST (5%)
     *          Total Price
     *  
     *          Our Various menus and Error Handling.
     *          
     * Written By: David Bergeron
     * Date Modified: 2018.10.22
     * */
    class Program
    {
        static void Main(string[] args)
        {
            // Declare my Constants
            const double taxRate = 0.05;           
            const double wasteFactor = 1.10;

            const double gateFixedPrice = 120;
            const double gatePricePerSqFt = 15.75;

            // Declare Default Price Settings
            // Fence Variables - Default to SPRUCE
            string fenceTypeStr = "Spruce";
            double fencePricePerSqFt = 4.50;
            double postPrice = 17.20;
            double railPricePerFoot = 0.49;

            // Paint Variables - Default to BASIC paint.
            string paintTypeStr = "Basic";
            double paintPricePerBucket = 11.99;
            double sqFtPaintPerQuart = 75;

            //// Declare inputs.
            double fenceLength = 0;
            double fenceWidth = 0;
            double fenceHeight = 0;

            double postDistance = 0;

            double gateWidth = 0;
            double gateHeight = 0;

            // Declare Process variables (Stuff we need to calculate)
            double totalPerimeter;
            double fencePerimeter;
            double fenceSqFt;
            double fenceMaterial;
            double fenceCost;

            double numPosts = 0;
            double postCost = 0;

            double feetOfRailing = 0;
            double railMaterial = 0;
            double railCost = 0;

            double quartsOfPaint = 0;
            double numPaintBuckets = 0;
            double paintCost = 0;

            double gateMaterial = 0;
            double gateCost = 0;

            double netPrice = 0;
            double taxAmount = 0;
            double totalPrice = 0;


            // Menu Loop - Runs until user exits.
            bool running = true;
            while (running)
            {
                DrawMenu();
                switch ( GetMode() )
                {
                    // Quit Application
                    case 0:
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;

                    // Set Playground Dimensions
                    case 1:
                        Console.Clear();
                        Console.WriteLine(" Fence Dimensions");
                        fenceWidth  = GetPositiveNumber("Width");
                        fenceLength = GetPositiveNumber("Length");
                        fenceHeight = GetPositiveNumber("Height");
                        break;

                    // Set Gate Dimensions
                    case 2:
                        Console.Clear();
                        Console.WriteLine(" Gate Dimensions");
                        gateWidth  = GetPositiveNumber("Width");
                        gateHeight = GetPositiveNumber("Height");
                        break;

                    // Set Distance Between Posts
                    case 3:
                        Console.Clear();
                        Console.WriteLine(" Distance Between Posts");
                        postDistance = GetPositiveNumber("Distance");
                        break;

                    // Set Fence Type
                    case 4:
                        DrawFenceMenu();
                        SetFencePrice(out fenceTypeStr,
                                      out fencePricePerSqFt,
                                      out postPrice,
                                      out railPricePerFoot);
                        break;
                    
                    // Set Paint Type
                    case 5:
                        DrawPaintMenu();
                        SetPaintType(out paintTypeStr,
                                     out paintPricePerBucket,
                                     out sqFtPaintPerQuart);
                        break;

                    // Create Packing Slip (Print Results)
                    case 6:
                        /* FENCING MATERIAL CALCULATION
                         * We calculate our total fencingMaterial by:
                         *    - Calculating the total perimeter of the playground
                         *    - Determining perimeter of the fence by subtracting the width of 
                         *      the gate.
                         *    - calculating Square Footage of our Fence 
                         *      (fencePerimeter * fenceHeight)
                         *    - Making sure to factor in our waste ratio. */

                        totalPerimeter = (fenceLength * 2) + (fenceWidth * 2);
                        fencePerimeter = totalPerimeter - gateWidth;

                        fenceSqFt = fencePerimeter * fenceHeight;
                        fenceMaterial = Math.Ceiling(fenceSqFt * wasteFactor);

                        fenceCost = fenceMaterial * fencePricePerSqFt;

                        /* POST CALCULATIONS 
                         * We calculate the number of posts by:
                         *   - dividing the lineal footage of the fence by the distance between posts.
                         *   - Rounding up the nearest whole number (using Math.Ceiling)
                         *   - Adding an extra post for the first corner. */

                        if (postDistance == 0)
                        {
                            numPosts = 0;
                        }
                        else
                        {
                            numPosts = Math.Ceiling((totalPerimeter / postDistance)) + 1;
                        }

                        // Calculate the net cost for our posts.
                        postCost = numPosts * postPrice;


                        /* RAILING CALCULATIONS
                         * Calculate how many feet of Railing we need by:
                         *   - multiplying our fence perimeter by 2 (for the top rail and the bottom rail)
                         *   - multiply our linear feet of railing by the waste factor. */

                        feetOfRailing = fencePerimeter * 2;
                        railMaterial = Math.Ceiling(feetOfRailing * wasteFactor);

                        // Calculate net cost of our railing.
                        railCost = railMaterial * railPricePerFoot;


                        /* PAINT CALCULATIONS
                         * Calculate how much paint we need by:
                         *      - divide the Square Footage of fence we need to paint by 100.
                         *         - Need to paint both sides of the fence, so double our fence SquareFootage.
                         *         - Each gallon of paint covers 400 SQFT of fence.
                         *         - There are 4 Quarts of paint per gallon, so each quart of paint
                         *           covers 100 Square Feet of Fence
                         *      - Making sure to include our WASTE_FACTOR
                         *      - Rounding up to the nearest whole number (We can't buy half a bucket of paint) */

                        if (fenceTypeStr == "Chain Link")
                        {
                            quartsOfPaint = 0;
                            numPaintBuckets = 0;
                        }
                        else
                        {
                            quartsOfPaint = (fenceSqFt * 2) / sqFtPaintPerQuart;
                            numPaintBuckets = Math.Ceiling(quartsOfPaint);
                        }

                        // Calculate net cost of our paint.
                        paintCost = numPaintBuckets * paintPricePerBucket;


                        /* GATE CALCULATIONS
                         *  Calculate how much gate material we need by:
                         *     - Making sure we have a gate
                         *     - determining Square Footage of our gate (gateWidth * gateHeight) 
                         *     - Making sure to include our WASTE_FACTOR */

                        gateMaterial = gateWidth * gateHeight;

                        // Calculate Net cost for the gate, including fixed cost.
                        if (gateMaterial > 0)
                        {
                            gateCost = gateFixedPrice + (gateMaterial * gatePricePerSqFt);
                        } else
                        {
                            gateCost = 0;
                        }


                        /* Total Price Calculations */
                        netPrice = fenceCost + postCost + railCost + gateCost + paintCost;
                        taxAmount = netPrice * taxRate;
                        totalPrice = netPrice + taxAmount;

                        // PRINT PACKING SLIP
                        Console.Clear();
                        Console.WriteLine("Invoice and Packing Slip\n");

                        // Report Fence Cost
                        ReportCost(fenceTypeStr, 
                                   fenceMaterial, 
                                   "^ft.", 
                                   fencePricePerSqFt, 
                                   fenceCost);

                        // Report Post Cost
                        ReportCost("Posts", 
                                   numPosts, 
                                   "", 
                                   postPrice, 
                                   postCost);

                        // Report Railing Cost
                        ReportCost("Railing",
                                   railMaterial,
                                   "ft.",
                                   railPricePerFoot,
                                   railCost);

                        // Report Gate Cost
                        ReportGateCost(gateCost);

                        // Report Paint Cost
                        ReportCost(paintTypeStr,
                                   numPaintBuckets,
                                   "qts.",
                                   paintPricePerBucket,
                                   paintCost);

                        // Report our Totals
                        Console.WriteLine();
                        ReportTotal("Net Price", netPrice);
                        ReportTotal("GST", taxAmount);
                        ReportTotal("Total", totalPrice);
                        Console.WriteLine("\nPress Enter to return to menu...");
                        Console.ReadLine();
                        break;
                    
                    // Invalid Input
                    default:
                        Console.WriteLine("Invalid Input. Press Any key to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("\tDefault Settings include Spruce Lumber and Basic Paint");
            Console.WriteLine();
            Console.WriteLine(" 1. Playground Dimensions");
            Console.WriteLine(" 2. Gate Dimensions");
            Console.WriteLine(" 3. Distance Between Posts");
            Console.WriteLine(" 4. Fence Type");
            Console.WriteLine(" 5. Paint Type");
            Console.WriteLine(" 6. Create Packing Slip");
            Console.WriteLine(" 0. Exit");
        }

        /* Get the input required to navigate the main menu */
        static int GetMode()
        {
            int mode = (int)GetNumber("\tMake a Selection");
            if (mode < 0 || mode > 6)
            {
                DrawMenu();
                Console.WriteLine("Error: Invalid menu choice selected. Enter 0-6.");
                return GetMode();
            } else {
                return mode;
            }
        }

        static void DrawFenceMenu()
        {
            Console.Clear();
            Console.WriteLine("Fence Type");
            Console.WriteLine($"\t 1. Spruce \t/   4.50 ^ft.");
            Console.WriteLine($"\t 2. Cedar \t/   7.25 ^ft.");
            Console.WriteLine($"\t 3. Chain Link \t/   13.50 ^ft.");
        }

        // Set our Fence values by passing the variables by Reference.
        static void SetFencePrice(out string fenceStr,
                                  out double fencePrice,
                                  out double postPrice,
                                  out double railPrice)
        {
            const double sprucePrice = 4.50;
            const double sprucePostPrice = 17.20;
            const double spruceRailPrice = 0.49;

            const double cedarPrice = 7.25;
            const double cedarPostPrice = 23.99;
            const double cedarRailPrice = 0.69;

            const double chainLinkPrice = 13.5;
            const double chainLinkPostPrice = 50.79;
            const double chainLinkRailPrice = 2.49;

            // Collect our Input
            int fenceType = 1;
            bool validInput = false;
            while (validInput == false)
            {
                fenceType = (int)GetNumber("\t Choose your fence type");
                if (fenceType < 1 || fenceType > 3)
                {
                    DrawFenceMenu();
                    Console.WriteLine("\t\t Invalid Option. Enter a number from 1-3.");
                } else
                {
                    validInput = true;
                }
            }

            switch (fenceType)
            {
                case 1:
                    fenceStr = "Spruce";
                    fencePrice = sprucePrice;
                    postPrice = sprucePostPrice;
                    railPrice = spruceRailPrice;
                    break;

                case 2:
                    fenceStr = "Cedar";
                    fencePrice = cedarPrice;
                    postPrice = cedarPostPrice;
                    railPrice = cedarRailPrice;
                    break;

                case 3:
                    fenceStr = "Chain Link";
                    fencePrice = chainLinkPrice;
                    postPrice = chainLinkPostPrice;
                    railPrice = chainLinkRailPrice;
                    break;

                default:
                    Console.WriteLine("\t\t Invalid Option (How did you get here?)");
                    SetFencePrice(out fenceStr, out fencePrice, out postPrice, out railPrice);
                    break;
            }
        }

        static void DrawPaintMenu()
        {
            Console.Clear();
            Console.WriteLine("Paint");
            Console.WriteLine("\t 1. Basic \t 11.99 / gallon");
            Console.WriteLine("\t 2. Premium \t 15.99 / gallon");
            Console.WriteLine("\t 3. Deluxe \t 19.99 / gallon");

        }

        // Set our paint values by passing the variables by reference. 
        static void SetPaintType(out string paintStr,
                                 out double paintPrice,
                                 out double paintPerQuart)
        {
            const string basicPaintStr = "Basic";
            const double basicPaintPrice = 11.99;
            const double basicPaintPerQuart = 300 / 4;

            const string premiumPaintStr = "Premium";
            const double premiumPaintPrice = 15.99;
            const double premiumPaintPerQuart = 400 / 4;

            const string deluxePaintStr = "Deluxe";
            const double deluxePaintPrice = 19.99;
            const double deluxePaintPerQuart = 500 / 4;

            // Verify our Input
            int paintType = 1;
            bool validInput = false;
            while (validInput == false)
            {
                paintType = (int)GetNumber("\t Choose your paint type");
                if (paintType < 1 || paintType > 3)
                {
                    DrawPaintMenu();
                    Console.WriteLine("\t\t Invalid Option. Enter a number from 1-3.");
                } else
                {
                    validInput = true;
                }
            }

            // Depending on user input, change Paint Type
            switch (paintType)
            {
                case 1:
                    paintStr = basicPaintStr;
                    paintPrice = basicPaintPrice;
                    paintPerQuart = basicPaintPerQuart;
                    break;

                case 2:
                    paintStr = premiumPaintStr;
                    paintPrice = premiumPaintPrice;
                    paintPerQuart = premiumPaintPerQuart;
                    break;

                case 3:
                    paintStr = deluxePaintStr;
                    paintPrice = deluxePaintPrice;
                    paintPerQuart = deluxePaintPerQuart;
                    break;

                default:
                    Console.WriteLine("Invalid Option. Enter 1-3 (How did we get here?)");
                    SetPaintType(out paintStr, out paintPrice, out paintPerQuart);
                    break;
            }
        }

        static double GetPositiveNumber(string msg)
        {
            double num = GetNumber(msg);
            if (num == 0)
            {
                Console.WriteLine("Invalid Input. Number cannot be Zero.");
                return GetPositiveNumber(msg);
            }
            return num;
        }

        static double GetNumber(string msg)
        {
            try
            {
                Console.Write($"\t {msg}: ");
                double num = double.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Invalid Input. Number must be positive.");
                    return GetNumber(msg);
                }
                return num;
            } catch (Exception e)
            {
                Console.WriteLine("Invalid Input. Not a Number.");
                return GetNumber(msg);
            }
        }

        /* Print The results for our packing slip */
        static void ReportCost(string itemName,
                               double numItems,
                               string numSuffix,
                               double pricePerItem,
                               double totalCost)
        {
            Console.WriteLine("  {0,-8:0.0} {1,5} {2,-20} @ {3,8:0.00} = {4,12:C}",
                              numItems,
                              numSuffix,
                              itemName,
                              pricePerItem,
                              totalCost 
            );
        }

        static void ReportGateCost(double gateCost)
        {
            double gateQuantity = 1.0;
            if (gateCost == 0)
            {
                gateQuantity = 0.0;
            }

            Console.WriteLine("  {0,-8:0.0} {1,5} {2,-20} @ {3,8:0.00} = {4,12:C}",
                                          gateQuantity,
                                          "",
                                          "Gate",
                                          "",
                                         gateCost);
        }

        /* Report our final Totals */
        static void ReportTotal(string name, double value)
        {
            Console.WriteLine("{0,-35} {1, -10}   = {2,12:C}",
                                            " ",
                                            name,
                                            value);
        }
    }
}