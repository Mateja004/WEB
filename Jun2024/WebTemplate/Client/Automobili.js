import { Iznajmljivanje } from "./Iznajmljivanje.js";

export class Automobili{
    constructor(container){
        this.container=container;
        this.modeli=[];
        this.filteri=[];

        const desniContainer=this.container.querySelector(".desni");
        this.iznajmljivanjeUI=new Iznajmljivanje(desniContainer);
    }



    async draw(){
        await this.VratiModele();
        await this.iznajmljivanjeUI.vratiAutomobile();
         this.iznajmljivanjeUI.draw();
        const leviContainer=this.container.querySelector(".levi1");
        const imeprezime=this.DodajInput(leviContainer, "imeiprezime", "Ime i prezime:","text");
        const jmbg=this.DodajInput(leviContainer, "jmbg", "JMBG:","text", 13);
        const dozvola=this.DodajInput(leviContainer, "dozvola", "Broj vozacke dozvole:","text", 9);
        const brojdana=this.DodajInput(leviContainer, "Broj dana", "Broj dana:","text");
       const  levi2Container=this.container.querySelector(".levi2");
       const kilometraza= this.DodajInput(levi2Container, "Kilometraza", "Predjena kilometraza:","text");
        const brojsedista=this.DodajInput(levi2Container, "Brojsedista", "Broj sedista:","text");
        const cena=this.DodajInput(levi2Container, "Cena", "Cena:","text");
        this.selectmodel=this.DodajSelect(levi2Container, "Model", "Model");
        const filterbutton=this.DodajButton(levi2Container,"Filtriraj prikaz:")
        filterbutton.classList.add("dugme");
        for(const m of this.modeli){
            const option=document.createElement("option");
            option.value=m.model;
            option.textContent=m.model;
            this.selectmodel.appendChild(option);
        }

        filterbutton.onclick=()=>this.Filtriraj(kilometraza, brojsedista,cena,this.selectmodel);
    }

    DodajInput(container, name, LabelText, type, maxlenght){
        const label=document.createElement("label");
        label.setAttribute("for", name);
        label.textContent=LabelText;
        container.appendChild(label);

        const input=document.createElement("input");
        input.name=name;
        input.type=type;
        if(maxlenght){
            input.maxLength=maxlenght;
        }
        container.appendChild(input);

        return input;
    }

    DodajSelect(container, name, LabelText,){
        const label=document.createElement("label");
        label.setAttribute("for", name);
        label.textContent=LabelText;
        container.appendChild(label);

        const select=document.createElement("select");
        select.id=name;

        container.appendChild(select);

        return select;
    }


    async VratiModele(){
        try{
            const response=await fetch(`https://localhost:7080/Ispit/VratiModele`);

            if(!response.ok){
                const error=await response.text();
                console.error(error);
            }
            const model=  await response.json();
            console.log(model);

            for(const m of model){
                this.modeli.push(m);
            }
        }catch(e){
            console.log(`Fetch error:${e}`);
        }
    }

    DodajButton(container, buttontext){
        const button=document.createElement("button");
        button.textContent=buttontext;
        container.appendChild(button);

        return button;
    }

    async Filtriraj(kilometraza, brojsedista, cenadana, model){
        try{

            const km=Number(kilometraza.value)||0;
            const sed=Number(brojsedista.value)||0;
            const cenaDana=Number(cenadana.value)||0;
            const modelVal=model.value||"";
            const response=await fetch(`https://localhost:7080/Ispit/Filtriraj?kilometraza=${km}&brsedista=${sed}&cenadana=${cenaDana}&model=${modelVal}`);

            if(!response.ok){
                const error=await response.text();
                console.error(error);
                return;
            }

            const filter=await response.json();
            console.log(filter);

            this.iznajmljivanjeUI.automobili=filter;
            this.iznajmljivanjeUI.draw();

        }catch(e){
            console.error(`Fetch failed:${e}`);
        }
    }
}