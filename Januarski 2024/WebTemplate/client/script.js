import { Dodaj } from "./Dodaj.js";

const container =document.createElement("div");
container.classList.add("container");

const sobe =document.createElement("div");
sobe.classList.add("sobe");

const dodaj=document.createElement("div");
dodaj.classList.add("dodaj");

container.append(dodaj, sobe);
document.body.append(container);

const levi=new Dodaj(container);
await levi.draw();