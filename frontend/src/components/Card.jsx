import React from "react";

export default function Card({ title, description, imageSrc }) {
	return (
		<div className="card w-96 bg-base-100 shadow-xl">
			<div className="card-body">
				<h2 className="card-title">{title}</h2>
				<p>{description}</p>
			</div>
			<figure>
				<img
					src={imageSrc}
					alt={title} 
				/>
			</figure>
		</div>
	);
}
