//Drag and drop

document.getElementById('ball2').onmousedown = function() {
  this.style.position = 'absolute'
 
  var self = this
 
  document.onmousemove = function(e) {
    e = e || event
    fixPageXY(e)
    
    self.style.left = e.pageX-25+'px'
    self.style.top = e.pageY-25+'px'
  }
  this.onmouseup = function() {
    document.onmousemove = null
  }
}
 
document.getElementById('ball2').ondragstart = function() { return false }
