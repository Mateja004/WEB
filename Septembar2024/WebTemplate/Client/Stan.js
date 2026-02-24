import { Racuni } from "./Racuni.js";
export class Stan{
    constructor(container){
        this.container=container;
        this.stanovi=[];
        this.infostanovi=[];
        this.racuniUI=null;
    }


    async draw(){
        await this.VratiIDStana();
        const DesniContainer=this.container.querySelector(".desni");
        this.racuniUI=new Racuni(DesniContainer);
        const LeviContainer=this.container.querySelector(".levi");
        this.selectstan=this.DodajSelect(LeviContainer, "stan", "Biraj stan:");
        const dugme=this.DodajButton(LeviContainer, "Prikaz informacija");
        dugme.classList.add("grid-2");

        for(const s of this.stanovi){
            const option=document.createElement("option");
            option.value=s.id;
            option.textContent=s.id;
            this.selectstan.appendChild(option);
        }
        this.infostanovi=document.createElement("div");
        LeviContainer.appendChild(this.infostanovi);
        dugme.onclick =()=>this.PrikaziStan();
    }

    DodajSelect(container, name, labelText){
        const label=document.createElement("label");
        label.setAttribute("for", name);
        label.textContent=labelText;
        container.appendChild(label);

        const select=document.createElement("select");
        select.id=name;
        container.appendChild(select);

        return select;
    }

    DodajButton(container, content){
        const button=document.createElement("button");
        button.textContent=content;
        container.appendChild(button);

        return button;
    }

   async VratiIDStana(){
        try{
            const response=await fetch("https://localhost:7080/Ispit/VratiStanove");
            if(!response.ok){
                const error=await response.text();
                console.error(error);
            }

            const stan=await response.json();
            console.log(stan);

            for(const s of stan){
                this.stanovi.push(s);
            }
        }catch(e){
            console.error(`Fetch failed:${e}`);
        }
    }

    async PrikaziStan(){

        const id=this.selectstan.value;

        const response =await fetch(`https://localhost:7080/Ispit/VratiStan/${id}`);

        const stan=await response.json();
        console.log(stan);

        this.infostanovi.innerHTML="";

        const broj=document.createElement("p");
        broj.textContent=`Broj stana: ${id}`;

        const ime=document.createElement("p");
        ime.textContent=`Ime vlasnika: ${stan.imeVlasnika}`;

        const povrsina=document.createElement("p");
        povrsina.textContent=`Povrsina: ${stan.povrsina}`;

        const clanovi=document.createElement("p");
        clanovi.textContent=`Broj clanova ${stan.brojClanova}`;

        this.infostanovi.append(broj,clanovi,ime, povrsina);

        await this.racuniUI.UcitajRanune(id);

        this.racuniUI.draw();
    }

}