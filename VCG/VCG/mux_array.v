module mux_array(
	input									CMOS					,
	input									clk_sys				,
//String Process label
	//stv
	input									stv1					,
	//ckv
	input									ckv1					,
	input									ckv2					,
	input									ckv3					,
	input									ckv4					,
	input									ckv5					,
	input									ckv6					,
	//ckh
	input									ckh1					,
	input									ckh2					,
	input									ckh3					,
	//grst
	input									grst					,
	//gas
	input									gas					,
	//jdqi
	input									jdqi					,
	//u2d
	input									u2d					,
	//d2u
	input									d2u					,
//String Process label
	output								mux_1					,
	output								mux_2					,
	output								mux_3					,
	output								mux_4					,
	output								mux_5					,
	output								mux_6					,
	output								mux_7					,
	output								mux_8					,
	output								mux_9					,
	output								mux_10				,
	output								mux_11				,
	output								mux_12				,
	output								mux_13				,
	output								mux_14				,
	output								mux_Test1				,
	output								mux_Test2				
);

//xckh
wire										xckh1			=(CMOS==1'b0)?1'b0:~ckh1;
wire										xckh2			=(CMOS==1'b0)?1'b0:~ckh2;
wire										xckh3			=(CMOS==1'b0)?1'b0:~ckh3;

mux_decode u1_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(stv1											),  //input
	.db									(stv1											),  //input
	.a										(mux_1										)   //output
);

mux_decode u2_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(ckv1											),  //input
	.db									(ckv2											),  //input
	.a										(mux_2										)   //output
);

mux_decode u3_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(ckv3											),  //input
	.db									(ckv4											),  //input
	.a										(mux_3										)   //output
);

mux_decode u4_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(ckv5											),  //input
	.db									(ckv6											),  //input
	.a										(mux_4										)   //output
);

mux_decode u5_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(1'b1											),  //input
	.db									(1'b1											),  //input
	.a										(mux_5										)   //output
);

mux_decode u6_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(ckh1											),  //input
	.db									(xckh1										),  //input
	.a										(mux_6										)   //output
);

mux_decode u7_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(ckh2											),  //input
	.db									(xckh2										),  //input
	.a										(mux_7										)   //output
);

mux_decode u8_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(ckh3											),  //input
	.db									(xckh3										),  //input
	.a										(mux_8										)   //output
);

mux_decode u9_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(u2d											),  //input
	.db									(d2u											),  //input
	.a										(mux_9										)   //output
);

mux_decode u10_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(grst											),  //input
	.db									(grst											),  //input
	.a										(mux_10										)   //output
);

mux_decode u11_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(gas											),  //input
	.db									(gas											),  //input
	.a										(mux_11										)   //output
);

mux_decode u12_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(1'b1											),  //input
	.db									(1'b1											),  //input
	.a										(mux_12										)   //output
);

mux_decode u13_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(VTCOMSW1									),  //input
	.db									(VTCOMSW2									),  //input
	.a										(mux_13										)   //output
);

mux_decode u14_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(jdqi											),  //input
	.db									(1'b1											),  //input
	.a										(mux_14										)   //output
);

mux_decode u15_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(1'b1											),  //input
	.db									(1'b1											),  //input
	.a										(mux_Test1									)   //output
);

mux_decode u16_mux_decode(
	.clk									(clk_sys										),  //input
	.da									(1'b1											),  //input
	.db									(1'b1											),  //input
	.a										(mux_Test2									)   //output
);

endmodule