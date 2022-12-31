fetch("apiLolItem.json")
    .then(function (response) {
        if (response.ok) {
            return response.json();
        } else {
            return Promise.reject(response.status);
        }
    })

    .then(function (response) {
        console.log(response);
        let html = `<article >`;
        final=[]
        const words = ['1001', '1011', '1018','1028','1029','1031','1033','1036','1037','1041'
        ,'1042','1043','1052','3006','2049','2045','1006','2053','3009','1038', '3031','3035']; //les 20 item choisi
        for (let i = 0; i < response.length; i++) {
                
                
            const avatar = response[i];
            
            // if (words.indexOf(avatar.id) !== -1) {
            //     //console.log("The item "+avatar.id);
            //     if( avatar.from!=null ){
            //         for (let i = 0; i < avatar.from.length; i++) {

            //             if (! (words.indexOf(avatar.from[i]) !== -1)) {
            //                 //console.log("From "+avatar.from[i])
            //                 avatar.from.splice( avatar.from.indexOf(avatar.from[i]), 1)
            //             }

            //         }
            //     }
                
            //     if( avatar.into != null){
            //         for (let i = 1; i < avatar.into.length; i++) {
            //             if ( (words.indexOf(avatar.into[i]) !== -1)) {
                            
            //             }
            //             else{
            //                 //console.log("Into "+avatar.into[i])
            //                 avatar.into.splice( avatar.into.indexOf(avatar.into[i]), 1)
            //             }
            //         }
            //     }
                avatar.id=parseInt(avatar.id);
           
                if(avatar.into!=null)
                    avatar.into=avatar.into.map(str => parseInt(str))
                if(avatar.from!=null)
                    avatar.from=avatar.from.map(str => parseInt(str))
                final.push(avatar);

              //} 

              
    
             
        }   
         
        console.log(final)
        
        json = JSON.stringify(final)   
        json=json.split("\n").join("")
        console.log(json)
            for (let i = 0; i < final.length; i++) {
                
                
                const avatar = final[i];
                if (words.indexOf(avatar.id) !== -1) {
                    console.log(avatar.id);
                    } else {
                    response.filter(fruit => fruit !== avatar);
                    console.log('The array does not contain the word "cat"');
                    }



                html += `
                        <p>Id ${avatar.id} : ${avatar.name}</p>
                        <article  class='gridwepon'>`;
                            html += `<div class='gridwepon1'>
                            <img src="${avatar.icon}" />
                            </div>`;
                            if( avatar.from!=null){
                                html += `<p>from</p>`
                                avatar.from.forEach(function(fromItem) {
                                    html += `<p>${fromItem} </p>`
                                });
                            }
                            if( avatar.into!=null){
                                html += `<p>into</p>`
                                avatar.into.forEach(function(intoItem) {
                                    html += `<p>${intoItem} </p>`
                                });
                            }
                        html += `--------------------------------------------------`        
                        html += `</article>`;          
            }
        html += '</article>';
        document.body.insertAdjacentHTML('beforeend', html);
    })
    .catch(function (error) {
        console.error("Error with message: " + error)
    });

