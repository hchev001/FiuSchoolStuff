///////////////////////////////////////////////////////////////////////////
// Inputs: Always clk and reset
//         Others are for your particular application.
// Outputs: Always will depend on your application.
module mycachecircuit(input logic clk,
                input logic reset,
		input logic valid,
		input logic tag,
		input logic mytag,
		output logic miss,
		output logic hit);

// What we are saying here is that we need two bits (1 down to 0)
// For states in our state machine
// Our states will be S0, S1, S2, S3
// Change this to accomodate how many states you have.
typedef enum logic[1:0] {S0, S1, S2, S3} statetype;

// These will almost always be the same
statetype state, nextstate;

// Flip-flop for states (same for each)
// The flip-flop is triggered when clk goes to 1, or reset goes to 1
// Posedge = positive(1) edge for clk
always_ff@(posedge clk, posedge reset)
   if (reset) state <= S0;
   else state <= nextstate;

// State diagram here.
// Change for your state diagram.
always_comb
   case (state)
      S0: if (valid) nextstate <= S1;
          else nextstate <= S2;
      S1: if (mytag == tag) nextstate <= S3;
          else nextstate <= S2;
      S2: nextstate <= S0;
      S3: nextstate <= S0;
endcase

// Output logic: We hit if we reach S3
//               We miss if we reach S2.
assign miss = (state == S2);
assign hit = (state == S3);

endmodule

