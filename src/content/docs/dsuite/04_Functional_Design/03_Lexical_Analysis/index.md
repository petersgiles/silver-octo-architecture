# Lexical Analysis

## Chat bots and callouts

The message/discussuion requirements are much akin to many bots you might see in IRC or Chat apps like telegram

## Nearley

Parsers turn strings of characters into meaningful data structures (like a JSON object!). Nearley is a fast, feature-rich, and modern parser toolkit for JavaScript.

## Links

[https://nearley.js.org/](https://nearley.js.org/)
[https://github.com/petersgiles/nearley-playground](https://github.com/petersgiles/nearley-playground)


```

main -> sentence

sentence -> ( word | person | bot | bang | ws):+ {% function(d) { 	
	var tokens = d[0].reduce(function(acc,i) {
		if(i[0].type == "PERSON" || i[0].type == "BOT" || i[0].type == "BANG")
			acc.push(i[0])
		return acc
	},[])
			  
	return tokens
} %}


word -> (" " [a-zA-Z]:+) {% function(d) { 
	var val = d[0][1].join('')
	return { type:'WORD', value: val} 
} %}

person -> ("@" [a-zA-Z]:+) {% function(d) { 
	var val = d[0][1].join('')
	return { type:'PERSON', value: val}  
} %}

bot -> ("/" [a-zA-Z]:+) {% function(d) { 
	var val = d[0][1].join('')
	return { type:'BOT', value: val}  
} %}

bang -> ("!" [a-zA-Z]:+) {% function(d) { 
	var val = d[0][1].join('')
	return { type:'BANG', value: val}  
} %}

ws -> " " {% function(d) { 
	return { type:'WS', value: null}  
} %}



```