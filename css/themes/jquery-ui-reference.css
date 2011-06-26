$(document).ready(function() {
	//Stylize the UI	
	$(".selection").buttonset();
	$("#outcomes").button();
	showOutcomes();
	$("button").click(function() {
	  showOutcomes();
	});
	$("input").change(function() {
	  showOutcomes();
	});
});

function showOutcomes() {
	var openlist = "<p class=\"ui-widget-content\">";
	var closelist = "</p>";
	var list = "";
	var list2 = "";
	var listsep = "<br>";
	
	var mob = [];
	$('input:checkbox[name="mob"]').each(function(index) { mob.push(this.checked); });
	var totalmob = $("input:[name=mob]:checked").length;
	var outs = $("input:radio[name=outs]:checked").val();
	var strikes = $("input:radio[name=strikes]:checked").val();
	var balls = $("input:radio[name=balls]:checked").val();	
	
	var base_changes_no_runner = base_changes(mob, 0);
	
	//Straight steals
	for (i = 0; i < base_changes_no_runner.length; i++) {
		list += openlist;
		for (j = 0; j < 3; j++) {
			if (base_changes_no_runner[i][j]) {
				list += movePlayer(j, j + base_changes_no_runner[i][j], "steals") + listsep;
			}
		}
		list += get_runs(base_changes_no_runner[i]) + " runs scored";
		list += closelist;
	}
	
	$("#debug").html(
	  "<b>Outs:</b> " + outs + "<br>" +
	  "<b>Strikes:</b> " + strikes + "<br>" +
	  "<b>Balls:</b> " + balls + "<br>" +
	  "<b>Men on base:</b> " + totalmob + "<br>" +
	  base_changes_no_runner
	);
	
	$("#outcomelist").html(list);
}

function get_base_name(base) {
	switch (base)
	{
	case 0: return "1st";
	case 1: return "2nd";
	case 2: return "3rd";
	default: return "home";
	}
}

function movePlayer(fromBase, toBase, how) {
	return "Player on " + get_base_name(fromBase) + " " + how + " " + get_base_name(toBase);
}
		
function base_changes(mob, batter) {
	var totalmob = 0;
	var retpos = [];
	for (i = 0; i < 3; i++) { if (mob[i]) { totalmob++; } }

	if (!batter) {
		if (totalmob == 1) {
			var manon = 0;
			for (i = 0; i < 3; i++) { if (mob[i]) { manon = i; } }
			for (i = 0; i < 3 - manon; i++) {
				var temppos = [0, 0, 0, 0];
				temppos[manon] = i + 1;
				retpos.push(temppos);
			}
			return retpos;
		}
		//Two men on
		else if (totalmob == 2) {
			var temppos = [0, 0, 0, 0];
			//[1, 1, 0, 0]
			if (mob[0] && (mob[1])) {
				//Lead runner advances
				retpos.push([0, 1, 0, 0]);			
				//Both runners advance
				retpos.push([1, 1, 0, 0]);
				//Lead runner advances two bases
				retpos.push([0, 2, 0, 0]);
				//Lead runner 2, trailing runner 1
				retpos.push([1, 2, 0, 0]);
				//Runners advance two bases
				retpos.push([2, 2, 0, 0]);
				retpos.push([3, 2, 0, 0]);
			}
			else if (mob[1] && (mob[2])) {
				//Lead runner scores
				retpos.push([0, 0, 1, 0]);			
				//Both runners advance
				retpos.push([0, 1, 1, 0]);
				//Both runners score
				retpos.push([0, 2, 1, 0]);
			}
			//[1,0,1,0]
			else if (mob[0] && mob[2]) {
				//Lead runner scores
				retpos.push([0, 0, 1, 0]);			
				//Trailing runner advances
				retpos.push([1, 0, 0, 0]);
				//Both runners advance
				retpos.push([1, 0, 1, 0]);
				//3rd and scores
				retpos.push([2, 0, 1, 0]);
				//Both runners score
				retpos.push([3, 0, 1, 0]);
			}			
			return retpos;
		}	
		else if (totalmob == 3) {
			retpos.push([0, 0, 1, 0]);
			retpos.push([0, 1, 1, 0]);
			retpos.push([1, 1, 1, 0]);
			retpos.push([1, 2, 1, 0]);
			retpos.push([2, 2, 1, 0]);
			retpos.push([3, 2, 1, 0]);
			return retpos;
		}
	}
	return retpos;
}

function get_runs(bases) {
	var runs = 0;
	for (k = 0; k < 3; k++) {
		if ((bases[k] + k) == 3) {
			runs++;
		}
	}
	return runs;
}