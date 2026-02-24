import { Automobili } from "./Automobili.js";
const container=document.createElement("div");
container.classList.add("container");
document.body.append(container);

const levi=document.createElement("div");
levi.classList.add("levi");
container.appendChild(levi);

const levi1=document.createElement("div");
levi1.classList.add("levi1");
levi.appendChild(levi1);

const levi2=document.createElement("div");
levi2.classList.add("levi2");
levi.appendChild(levi2);

const desni=document.createElement("div")
desni.classList.add("desni");
container.appendChild(desni);

const obj =new Automobili(container)
await obj.draw();






