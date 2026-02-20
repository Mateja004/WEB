export class Dodaj{
    constructor(container){
        this.container=container;
        this.korisnici=[];
    }

     async draw(){
        await this.VratiKorisnike();
        const DodajContainer=this.container.querySelector(".dodaj");
        this.dodajinput(DodajContainer,"soba", "Soba:","text");
        const selectkorisnik=this.dodajSelect(DodajContainer,"korisnik", "Korisnik:");
        this.dodajinput(DodajContainer,"nadimak", "Nadimak:", "text");
        this.dodajinput(DodajContainer,"boja", "Boja:", "color");
        const dugme= this.dodajButton(DodajContainer,"Dodaj");
        dugme.classList.add("grid-column-span-2");

        for(const a of this.korisnici){
            const option=document.createElement("option");
            option.value=a.id;
            option.textContent= a.korisnickoime;
            selectkorisnik.appendChild(option);
        }

    }

    dodajSelect(container,name, labelText){
        const label =document.createElement("label");
        label.setAttribute("for", name);
        label.textContent=labelText;
        container.appendChild(label);

        const select =document.createElement("select");
        select.id=name;
        select.name=name;
        container.appendChild(select);

        return select;
    }

    dodajinput(container, name, labelText,type){
        const label =document.createElement("label");
        label.setAttribute("for", name);
        label.textContent=labelText;
        container.appendChild(label);

        const input =document.createElement("input");
        input.id=name;
        input.name=name;
        input.type=type;
        container.appendChild(input);

        return input;

    }

    dodajButton(container, content){
        const button=document.createElement("button");
        button.textContent=content;
        container.appendChild(button);

        return button;
    }

    async VratiKorisnike(){
        try{
            const response=await fetch("https://localhost:7080/Ispit/VratiKorisnike");
            if(!response.ok){
                const error =await response.text();
                console.error(error);
            }

            const kor=await response.json();

            for(const a of kor){
                this.korisnici.push(a);
            }

        }catch(e){
            console.error(`Fetch failed: ${e}`);
        }
    }
}