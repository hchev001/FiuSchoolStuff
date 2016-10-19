module testbench();
	// Place inputs here
	reg clk, reset, Op1, Op0, A, B, Binv, Cin;

	// Outputs
	wire Y1, Y0, Zero, Error;

	// A oneBitAdderALU instance
	project4 theALU(clk, reset, Op1, Op0, A, B, Binv, Cin, Y1, Y0, Zero, Error);

	// Test all combinations
	initial begin
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 0;  Binv = 0;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 0;  Binv = 0;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 0;  Binv = 1;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 0;  Binv = 1;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 1;  Binv = 0;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 1;  Binv = 0;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 1;  Binv = 1;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 0;  B = 1;  Binv = 1;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 0;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 0;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 0;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 0;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 1;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 1;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 1;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 0;  A = 1;  B = 1;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 0;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 0;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 0;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 0;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 1;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 1;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 1;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 0;  B = 1;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 0;  Binv = 0;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 0;  Binv = 0;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 0;  Binv = 1;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 0;  Binv = 1;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 1;  Binv = 0;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 1;  Binv = 0;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 1;  Binv = 1;  Cin = 0; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 0;  Op0 = 1;  A = 1;  B = 1;  Binv = 1;  Cin = 1; #400;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 0;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 0;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 0;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 0;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 1;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 1;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 1;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 0;  B = 1;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 0;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 0;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 0;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 0;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 1;  Binv = 0;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 1;  Binv = 0;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 1;  Binv = 1;  Cin = 0; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 0;  A = 1;  B = 1;  Binv = 1;  Cin = 1; #600;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 0;  Binv = 0;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 0;  Binv = 0;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 0;  Binv = 1;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 0;  Binv = 1;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 1;  Binv = 0;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 1;  Binv = 0;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 1;  Binv = 1;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 0;  B = 1;  Binv = 1;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 0;  Binv = 0;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 0;  Binv = 0;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 0;  Binv = 1;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 0;  Binv = 1;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 1;  Binv = 0;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 1;  Binv = 0;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 1;  Binv = 1;  Cin = 0; #200;
	reset = 1; #100
	reset = 0;
	Op1 = 1;  Op0 = 1;  A = 1;  B = 1;  Binv = 1;  Cin = 1; #200;
	reset = 1; #100
	reset = 0;

	end

endmodule
				
				