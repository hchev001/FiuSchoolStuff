module testbench();
	// Place inputs here
	reg clk, reset, valid, tag, mytag;

	// Outputs
	wire miss, hit;

	// A mycachecircuit instance
	mycachecircuit theCache(clk, reset, valid, tag, mytag, miss, hit);

	// Test all combinations
	initial begin
		reset = 1; #100;
		reset = 0; 
		valid = 0; tag = 0; mytag = 0; #200;  // Miss, 2 State Changes  0->2->0
		valid = 0; tag = 0; mytag = 1; #200;  // Miss, 2 State Changes  0->2->0
		valid = 0; tag = 1; mytag = 0; #200;  // Miss, 2 State Changes  0->2->0
		valid = 0; tag = 1; mytag = 1; #200;  // Miss, 2 State Changes  0->2->0
		valid = 1; tag = 0; mytag = 0; #300;  // Hit, 3 State Changes   0->1->3->0
		valid = 1; tag = 0; mytag = 1; #300;  // Miss, 3 State Changes  0->1->2->0 
		valid = 1; tag = 1; mytag = 0; #300;  // Miss, 3 State Changes  0->1->2->0
		valid = 1; tag = 1; mytag = 1; #300;  // Hit, 3 State Changes   0->1->3->0
	end

endmodule
				