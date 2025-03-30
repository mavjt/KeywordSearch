import React from "react";
export default function SearchButton({  isWaiting }) {
    //return <button disabled={isWaiting} onClick={e => handleClick(e)}> {isWaiting ? "Submitting..." : "Search"}</button>
    return <button disabled={isWaiting}> {isWaiting ? "Submitting..." : "Search"}</button>

}