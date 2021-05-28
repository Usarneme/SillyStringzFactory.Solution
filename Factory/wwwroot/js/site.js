$(".remove-association-button").on("click", function(event) {
  event.preventDefault();
  const url = `/remove_license/${this.id}`
  fetch(url, { method: "POST" })
    .then(data => {
      if (data.status === 200) {
        $(`#${this.id}`).parent().remove()
        alert("License To Work On Machine Revoked.")
      }
    })
})
