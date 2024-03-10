const host = document.body;//host svega gde se iscrtava

//zovemo serverski deo app

const sm= await fetch("https://localhost:5001/Merac/PreuzmiSveMerace");
