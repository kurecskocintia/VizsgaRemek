import { useState } from "react";
import AvpnBadge from "./AvpnBadge";

const initial = {
  balls: 4, ballWeight: 250, hydration: 62, salt: 2.8,
  yeastType: "fresh", roomTemp: 23, roomHours: 6, fridgeTemp: 4, fridgeHours: 18
};

export default function DoughForm({ onCalculate, loading }) {
  const [v,setV]=useState(initial);
  const set=(k,val)=>setV(s=>({...s,[k]:val}));
  const hydrationOk=v.hydration>=55 && v.hydration<=62;
  const saltOk=v.salt>=2.5 && v.salt<=3.75;
  return <form className="card form" onSubmit={e=>{e.preventDefault();onCalculate(v)}}>
    <div className="grid two">
      <label>Gombócok száma<input type="number" min="1" max="30" value={v.balls} onChange={e=>set("balls",+e.target.value)}/></label>
      <label>Gombóc tömege (g)<input type="number" min="100" max="500" value={v.ballWeight} onChange={e=>set("ballWeight",+e.target.value)}/></label>
    </div>
    <div className="grid two">
      <label>Hidratáció (%)<input type="number" step="0.1" min="45" max="90" value={v.hydration} onChange={e=>set("hydration",+e.target.value)}/><AvpnBadge ok={hydrationOk}>{hydrationOk?"AVPN-tartomány":"AVPN-n kívül"}</AvpnBadge></label>
      <label> Só (%)<input type="number" step="0.1" min="0" max="6" value={v.salt} onChange={e=>set("salt",+e.target.value)}/><AvpnBadge ok={saltOk}>{saltOk?"AVPN-tartomány":"AVPN-n kívül"}</AvpnBadge></label>
    </div>
    <label>Élesztő / kovász típusa
      <select value={v.yeastType} onChange={e=>set("yeastType",e.target.value)}>
        <option value="fresh">Friss élesztő</option><option value="dry">Sörélesztő / szárított élesztő</option>
        <option value="liquidSourdough">Folyékony kovász (li.co.li.)</option><option value="lievitoMadre">Lievito madre</option>
      </select>
    </label>
    <h3>Szobahőmérsékletű fermentáció</h3>
    <div className="grid two">
      <label>Hőmérséklet (°C)<input type="number" step="0.5" min="10" max="35" value={v.roomTemp} onChange={e=>set("roomTemp",+e.target.value)}/></label>
      <label>Idő (óra)<input type="number" step="0.5" min="0" max="72" value={v.roomHours} onChange={e=>set("roomHours",+e.target.value)}/></label>
    </div>
    <h3>Hűtőben</h3>
    <div className="grid two">
      <label>Hőmérséklet (°C)<input type="number" step="0.5" min="1" max="12" value={v.fridgeTemp} onChange={e=>set("fridgeTemp",+e.target.value)}/></label>
      <label>Idő (óra)<input type="number" step="0.5" min="0" max="168" value={v.fridgeHours} onChange={e=>set("fridgeHours",+e.target.value)}/></label>
    </div>
    <button className="primary" disabled={loading}>{loading?"Számolás…":"🍕 Recept kiszámítása"}</button>
  </form>
}