export default function AvpnBadge({ ok, children }) {
  return <span className={"badge " + (ok ? "badge-ok" : "badge-bad")}>{ok ? "✓" : "!"} {children}</span>
}