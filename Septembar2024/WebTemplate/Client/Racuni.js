export class Racuni{
    constructor(container){
        this.container=container;
        this.racuni=[];
    }


    async UcitajRanune(stanID){
        const response=await fetch(`https://localhost:7080/Ispit/VratiRacune/${stanID}`);

        this.racuni=await response.json();
    }

    draw(){
        this.container.innerHTML="";

        this.racuni.forEach(racun =>{
            const kartica=document.createElement("div");

            kartica.append(
                this.NapraviRed("Mesec", racun.mesecIzdavanja),
                this.NapraviRed("Voda", racun.cenaVode),
                this.NapraviRed("Struja", racun.cenaStruje),
                this.NapraviRed("Komunalije", racun.komUsluge),
                this.NapraviRed("Placen", racun.placen? "Da":"Ne")
            );

            this.container.appendChild(kartica);
        });

    }

    NapraviRed(label, value){
        const p=document.createElement("p");

        p.textContent=`${label}: ${value}`;

        return p;
    }
}