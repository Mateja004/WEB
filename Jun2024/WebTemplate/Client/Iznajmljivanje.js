export class Iznajmljivanje{
    constructor(container){
        this.container=container;
        this.automobili=[];
    }


    iznajmi(){

    }

    async draw(){
        this.container.innerHTML="";
        this.automobili.forEach(a=>{
            const div = document.createElement("div");
            div.classList.add("autokartica");
           
            div.append(
                this.napraviParagraf("Model", a.model),
                this.napraviParagraf("Kilometraza",a.predjenaKilometraza),
                this.napraviParagraf("Godiste", a.godiste),
                this.napraviParagraf("Broj sedista", a.brojSedista),
                this.napraviParagraf("Cena po danu", a.cenapodanu),
                this.napraviParagraf("Iznajmljen", a.iznajmljen),
            );
            this.container.appendChild(div);
        });
    }

    async vratiAutomobile(){
        try{
            const response = await fetch(`https://localhost:7080/Ispit/VratiAutomobile`);
            this.automobili = await response.json();
            
    
        }catch(e){
            console.log(e);
            return;
        }
    }
    napraviParagraf(textContent,label){
        const par = document.createElement("p");
        par.innerText = `${textContent} : ${label}`;
        return par; 
    }
}