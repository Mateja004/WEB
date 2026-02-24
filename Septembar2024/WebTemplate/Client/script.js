import { Stan } from "./Stan.js";

const container=document.createElement("div");
container.classList.add("container");
document.body.append(container);

const levi=document.createElement("div");
levi.classList.add("levi");
container.appendChild(levi);

const desni=document.createElement("div");
desni.classList.add("desni");
container.appendChild(desni);

const obj=new Stan(container);
await obj.draw();