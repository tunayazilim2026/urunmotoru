"use client";
import { useState } from "react";

export default function Home() {
  const [xmlUrl, setXmlUrl] = useState("");
  const [data, setData] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);

  const fetchData = async () => {
    console.log("buton çalıştı");

    if (!xmlUrl) {
      alert("XML URL gir!");
      return;
    }

    try {
      setLoading(true);

      const res = await fetch("http://localhost:5188/api/xml/import", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ xmlUrl }),
      });

      const result = await res.json();
      console.log("gelen veri:", result);

      setData(result);
    } catch (err) {
      console.error("hata:", err);
      alert("Hata oluştu, console'a bak");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: 20 }}>
      <h1>XML Ürün Yükleme</h1>

      <input
        type="text"
        placeholder="XML URL gir"
        value={xmlUrl}
        onChange={(e) => setXmlUrl(e.target.value)}
        style={{ width: 400, padding: 10 }}
      />

      <br /><br />

      <button
        onClick={fetchData}
        style={{ padding: 10, cursor: "pointer" }}
      >
        {loading ? "Yükleniyor..." : "Getir"}
      </button>

      <hr />

      {data.length === 0 && <p>Veri yok</p>}

      {data.map((item, i) => (
        <div
          key={i}
          style={{ border: "1px solid #ccc", margin: 10, padding: 10 }}
        >
          <h3>{item.title}</h3>
          <p>{item.description}</p>
          <b>{item.price}</b>
        </div>
      ))}
    </div>
  );
}
